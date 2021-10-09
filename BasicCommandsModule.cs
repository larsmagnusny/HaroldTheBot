using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using HaroldTheBot.IP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{

    /* Create our class and extend from IModule */
    public class BasicCommandsModule : BaseCommandModule
    {
        /* Commands in DSharpPlus.CommandsNext are identified by supplying a Command attribute to a method in any class you've loaded into it. */
        /* The description is just a string supplied when you use the help command included in CommandsNext. */
        [Command("alive")]
        [Description("Simple command to test if the bot is running!")]
        public async Task Alive(CommandContext ctx)
        {
            /* Trigger the Typing... in discord */
            await ctx.TriggerTypingAsync();

            /* Send the message "I'm Alive!" to the channel the message was recieved from */
            await ctx.RespondAsync("I'm alive!");
        }

        [Command("surgeon")]
        [Description("Mention surgeons")]
        public async Task Surgeon(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var guilds = ctx.Client.Guilds;

            DiscordRole surgeon = null;

            foreach(var item in guilds)
            {
                foreach(var role in item.Value.Roles)
                {
                    if (role.Value.Name == "Surgeon")
                        surgeon = role.Value;
                }
            }

            if(surgeon != null)
                await ctx.RespondAsync(surgeon.Mention);
        }

        [Command("whereareyou")]
        [Description("A command to locate the bot and which operating system it is running on")]
        public async Task WhereAreYou(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var nameAndVersion = RuntimeInformation.OSDescription;
            var architecture = RuntimeInformation.OSArchitecture;
            var framework = RuntimeInformation.FrameworkDescription;

            string info = new WebClient().DownloadString("http://ipinfo.io");

            IpInfo ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);

            RegionInfo region = new(ipInfo.Country);

            await ctx.RespondAsync($"Hello! I am in {region.EnglishName}. \r\nI'm running on {nameAndVersion} {architecture} {framework}");

        }

        [Command("clear")]
        [Description("Command to remove all chats from channel")]
        public async Task Clear(CommandContext ctx)
        {
            if (ctx.Channel.Name == "bot-testing")
            {
                var Messages = await ctx.Channel.GetMessagesAsync(5000);

                await ctx.Channel.DeleteMessagesAsync(Messages);
            }
        }

        [Command("game")]
        [Description("Command to give a random game to play")]
        public async Task Game(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var game = RandomGame.Get();

            await ctx.RespondAsync($"You should play \"{game.Title}\". It was made by {game.Developer} and released {game.ReleaseDate}.");
        }

        [Command("mount")]
        public async Task Mount(CommandContext ctx, params string[] args)
        {
            await ctx.TriggerTypingAsync();

            if (args.Length == 0)
            {
                await ctx.RespondAsync("Usage: /mount [searchText]");
                return;
            }

            string search = args.Aggregate((a, b) => a + " " + b);

            foreach (var item in AllMounts.EmoteMount)
            {
                var emoji = DiscordEmoji.FromName(Program.DiscordClient, item.Key);
                if (search.Contains(emoji))
                    search = search.Replace(emoji, item.Value);
            }

            if (search.Length < 3)
            {
                await ctx.RespondAsync("I don't want to be spamming this channel so please define a search parameter with at least 3 characters.");
                return;
            }

            var mounts = AllMounts.Search(search);

            if (mounts.Count == 0)
            {
                await ctx.RespondAsync($"Sorry i could not find any mounts that has the name or description: \"{search}\"");
                return;
            }

            StringBuilder builder = new();

            foreach (var mount in mounts)
            {
                DiscordEmoji emoji = null;

                if (AllMounts.MountEmote.ContainsKey(mount.Name))
                    emoji = DiscordEmoji.FromName(Program.DiscordClient, AllMounts.MountEmote[mount.Name]);

                string stringToAdd = $"{(emoji ?? string.Empty)} **{mount.Name}**\n{mount.Description}\n\n";
                if (builder.Length + stringToAdd.Length > 2000)
                {
                    await ctx.RespondAsync(builder.ToString());
                    builder.Clear();
                }

                builder.Append(stringToAdd);
            }

            if (builder.Length > 0)
                await ctx.RespondAsync(builder.ToString());
        }

        [Command("mounts")]
        [Description("Command to list all mounts in the game")]
        public async Task Mounts(CommandContext ctx)
        {
            await ctx.TriggerTypingAsync();

            var mounts = AllMounts.GetAll();

            Dictionary<MountType, List<Mount>> mountByType = new();


            foreach (var mount in mounts)
            {
                if (!mountByType.ContainsKey(mount.MountType))
                    mountByType[mount.MountType] = new List<Mount>();

                mountByType[mount.MountType].Add(mount);
            }

            StringBuilder builder = new();

            foreach (var item in mountByType)
            {
                builder.Append(AllMounts.MountTypeDescriptions[item.Key]);
                builder.Append('\n');
                foreach (var mount in item.Value)
                {
                    DiscordEmoji emoji = null;

                    if (AllMounts.MountEmote.ContainsKey(mount.Name))
                        emoji = DiscordEmoji.FromName(Program.DiscordClient, AllMounts.MountEmote[mount.Name]);

                    string stringToAdd = $"{(emoji ?? string.Empty)} **{mount.Name}**\n{mount.Description}\n\n";
                    if (builder.Length + stringToAdd.Length > 2000)
                    {
                        await ctx.RespondAsync(builder.ToString());
                        builder.Clear();
                    }

                    builder.Append(stringToAdd);
                }

                builder.Append("\n\n");
            }

            if (builder.Length > 0)
                await ctx.RespondAsync(builder.ToString());


        }
    }
}
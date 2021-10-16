using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using HaroldTheBot.Raids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public static class MessageMonitorer
    {
        private static readonly Dictionary<string, StringComparison> StringBlacklist = new()
        {
            { "WoW", StringComparison.Ordinal },
            { "World of Warcraft", StringComparison.OrdinalIgnoreCase }
        };

        public static async void ReactionRemoved(DiscordClient s, MessageReactionRemoveEventArgs e)
        {
            var message = e.Message;
            if (message.Content == null)
            {
                message = await e.Channel.GetMessageAsync(e.Message.Id);
            }

            RaidEvent ev;
            VoteEvent vev;

            lock (RaidStorage.eventLock)
            {
                ev = RaidStorage.GetRaid(message.Id);
            }
            lock (VoteStorage.voteLock)
            {
                vev = VoteStorage.GetVote(message.Id);
            }

            if (ev != null)
                ev.ReactionRemoved(s, e, message);
            if (vev != null)
                vev.ReactionRemoved(s, e, message);
        }

        public static async void ReactionAdded(DiscordClient s, MessageReactionAddEventArgs e)
        {
            var message = e.Message;
            if (message.Content == null)
            {
                message = await e.Channel.GetMessageAsync(e.Message.Id);
            }

            RaidEvent ev;
            VoteEvent vev;

            lock (RaidStorage.eventLock)
            {
                ev = RaidStorage.GetRaid(message.Id);
            }
            lock (VoteStorage.voteLock)
            {
                vev = VoteStorage.GetVote(message.Id);
            }

            if (ev != null)
                ev.ReactionAdded(s, e, message);
            if (vev != null)
                vev.ReactionAdded(s, e, message);
        }

        public static async void MessageCreated(DiscordClient s, MessageCreateEventArgs e)
        {
            if (e.Message.Author.Username == "HaroldTheBot")
                return;

            bool triggered = false;
            string triggerStr = "We don't talk about that in here";
            foreach (var item in StringBlacklist)
            {
                if (e.Message.Content.Contains(item.Key, item.Value))
                {
                    triggered = true;
                    break;
                }
            }

            if (triggered)
            {
                await e.Message.RespondAsync(string.Concat("<@!", e.Message.Author.Id, "> ", triggerStr, ": ||~~", e.Message.Content, "~~||"));
                await e.Message.DeleteAsync("Offensive Content");
            }
        }
    }
}

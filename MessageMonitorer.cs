using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using HaroldTheBot.Raids;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public class MessageMonitorer : IMessageMonitorer
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public MessageMonitorer(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        private readonly Dictionary<string, StringComparison> StringBlacklist = new()
        {
            { "WoW", StringComparison.Ordinal },
            { "World of Warcraft", StringComparison.OrdinalIgnoreCase }
        };

        public async Task ReactionRemoved(DiscordClient s, MessageReactionRemoveEventArgs e)
        {
            var message = e.Message;
            if (message.Content == null)
            {
                message = await e.Channel.GetMessageAsync(e.Message.Id);
            }

            using var scope = _serviceScopeFactory.CreateScope();

            var raidService = (IRaidService)scope.ServiceProvider.GetService(typeof(IRaidService));

            var ev = raidService.GetRaid(message.Id);

            if (ev != null)
                ev.ReactionRemoved(s, e, message, raidService);

        }

        public async Task ReactionAdded(DiscordClient s, MessageReactionAddEventArgs e)
        {
            var message = e.Message;
            if (message.Content == null)
            {
                message = await e.Channel.GetMessageAsync(e.Message.Id);
            }
            using var scope = _serviceScopeFactory.CreateScope();

            var raidService = (IRaidService)scope.ServiceProvider.GetService(typeof(IRaidService));

            var ev = raidService.GetRaid(message.Id);

            if (ev != null)
                ev.ReactionAdded(s, e, message, raidService);
        }

        public async Task MessageCreated(DiscordClient s, MessageCreateEventArgs e)
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

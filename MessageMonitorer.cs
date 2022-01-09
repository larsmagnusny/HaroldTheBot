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
    public class MessageMonitorer : IMessageMonitorer
    {
        private readonly IRaidService _raidService;
        public MessageMonitorer(IRaidService raidService)
        {
            _raidService = raidService;
        }

        private readonly Dictionary<string, StringComparison> StringBlacklist = new()
        {
            { "WoW", StringComparison.Ordinal },
            { "World of Warcraft", StringComparison.OrdinalIgnoreCase }
        };

        public async void ReactionRemoved(DiscordClient s, MessageReactionRemoveEventArgs e)
        {
            var message = e.Message;
            if (message.Content == null)
            {
                message = await e.Channel.GetMessageAsync(e.Message.Id);
            }

            var ev = _raidService.GetRaid(message.Id); ;

            if (ev != null)
                ev.ReactionRemoved(s, e, message);
        }

        public async void ReactionAdded(DiscordClient s, MessageReactionAddEventArgs e)
        {
            var message = e.Message;
            if (message.Content == null)
            {
                message = await e.Channel.GetMessageAsync(e.Message.Id);
            }

            var ev = _raidService.GetRaid(message.Id);

            if (ev != null)
                ev.ReactionAdded(s, e, message);
        }

        public async void MessageCreated(DiscordClient s, MessageCreateEventArgs e)
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

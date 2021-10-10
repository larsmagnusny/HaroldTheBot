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

            lock (RaidStorage.eventLock)
            {
                ev = RaidStorage.GetRaid(message.Id);

                if (ev == null)
                    return;

                DiscordMember member = null;
                string NickName = e.User.Username;

                if (e.User.Presence == null)
                    member = null;
                else if (e.User.Presence.Guild != null)
                    e.User.Presence.Guild.Members.TryGetValue(e.User.Id, out member);

                if (member != null && !string.IsNullOrEmpty(member.Nickname))
                    NickName = member.Nickname;

                if (!ev.Participants.ContainsKey(e.User.Id))
                    return;

                RaidParticipant participant = ev.Participants[e.User.Id];

                if (participant.Role.ToString() == e.Emoji.Name.Trim(':'))
                    ev.Participants.Remove(e.User.Id);
            }

            await e.Message.ModifyAsync(ev.CreateMessage());
        }

        public static async void ReactionAdded(DiscordClient s, MessageReactionAddEventArgs e)
        {
            var message = e.Message;
            if (message.Content == null)
            {
                message = await e.Channel.GetMessageAsync(e.Message.Id);
            }

            lock (RaidStorage.eventLock)
            {
                var ev = RaidStorage.GetRaid(message.Id);

                if (ev != null)
                    ev.ReactionAdded(s, e, message);
            }
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

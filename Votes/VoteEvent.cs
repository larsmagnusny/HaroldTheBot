using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public class VoteOption
    {
        public DiscordEmoji Emoji { get; set; }
        public string EmojiStr { get; set; }
        public string Title { get; set; }
    }

    public class VoteEvent
    {
        public VoteEvent()
        {
            UserVotes = new Dictionary<ulong, UserVote>();
        }

        public ulong Id { get; set; }
        public ulong ChannelId { get; set; }
        private DiscordMessage message;

        public async Task<DiscordMessage> GetMessage()
        {
            var channel = await GetChannel();
            if (message == null)
            {
                message = await channel.GetMessageAsync(Id);
            }

            return message;
        }

        public void SetMessage(DiscordMessage _message)
        {
            message = _message;
        }

        private DiscordChannel channel;
        public async Task<DiscordChannel> GetChannel()
        {
            if (channel == null)
            {
                channel = await Program.DiscordClient.GetChannelAsync(ChannelId);
            }

            return channel;
        }
        public void SetChannel(DiscordChannel _channel)
        {
            channel = _channel;
        }
        public string Title { get; set; }
        public VoteOption[] Options { get; set; }
        public Dictionary<ulong, UserVote> UserVotes { get; set; }

        public async Task<DiscordMessage> UpdateMessage()
        {
            var message = await GetMessage();
            if (message != null)
            {
                return await message.ModifyAsync(CreateMessage());
            }
            return null;
        }

        public string CreateMessage()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"id: [{Id}]\n");
            builder.Append(Title);
            builder.Append("\n\n");

            Dictionary<int, int> voteCounter = new Dictionary<int, int>();

            foreach(var vote in UserVotes)
            {
                if(vote.Value.OptionId < Options.Length && vote.Value.OptionId >= 0)
                {
                    if (voteCounter.ContainsKey(vote.Value.OptionId))
                        voteCounter[vote.Value.OptionId]++;
                    else
                        voteCounter[vote.Value.OptionId] = 1;
                }
            }

            for(int i = 0; i < Options.Length; i++)
            {
                int numVotes = voteCounter.ContainsKey(i) ? voteCounter[i] : 0;

                builder.Append("      ");
                builder.Append(Options[i].Title);
                builder.Append(" (");
                builder.Append(numVotes);
                builder.Append(')');
            }

            return builder.ToString();
        }

        public async void ReactionAdded(DiscordClient s, MessageReactionAddEventArgs e, DiscordMessage message)
        {
            DiscordEmoji emojiToRemove = null;

            //lock (VoteStorage.voteLock)
            //{
            //    DiscordMember member = null;
            //    string NickName = e.User.Username;

            //    if (e.User.Presence == null)
            //        member = null;
            //    else if (e.User.Presence.Guild != null)
            //        e.User.Presence.Guild.Members.TryGetValue(e.User.Id, out member);

            //    if (!Enum.TryParse(typeof(Job), e.Emoji.Name.Trim(':'), out object job))
            //        return;

            //    if (member != null && !string.IsNullOrEmpty(member.Nickname))
            //        NickName = member.Nickname;

            //    if (Participants.ContainsKey(e.User.Id))
            //    {
            //        var prevParticipation = Participants[e.User.Id];

            //        emojiToRemove = DiscordEmoji.FromName(s, string.Concat(":", prevParticipation.Role.ToString(), ":"));

            //        Participants.Remove(e.User.Id);
            //    }

            //    Participants.Add(e.User.Id, new RaidParticipant
            //    {
            //        Role = (Job)job,
            //        Username = NickName
            //    });
            //}

            //if (emojiToRemove != null && message != null)
            //    await message.DeleteReactionAsync(emojiToRemove, e.User);

            //await message.ModifyAsync(CreateMessage());
        }

        public async void ReactionRemoved(DiscordClient s, MessageReactionRemoveEventArgs e, DiscordMessage message)
        {
            //lock (RaidStorage.eventLock)
            //{
            //    DiscordMember member = null;
            //    string NickName = e.User.Username;

            //    if (e.User.Presence == null)
            //        member = null;
            //    else if (e.User.Presence.Guild != null)
            //        e.User.Presence.Guild.Members.TryGetValue(e.User.Id, out member);

            //    if (member != null && !string.IsNullOrEmpty(member.Nickname))
            //        NickName = member.Nickname;

            //    if (!Participants.ContainsKey(e.User.Id))
            //        return;

            //    RaidParticipant participant = Participants[e.User.Id];

            //    if (participant.Role.ToString() == e.Emoji.Name.Trim(':'))
            //        Participants.Remove(e.User.Id);
            //}

            //await message.ModifyAsync(CreateMessage());
        }
    }
}

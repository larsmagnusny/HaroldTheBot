using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Raids
{
    public class RaidEvent
    {
        public RaidEvent()
        {
            TankLimit = 2;
            DPSLimit = 4;
            HealerLimit = 2;
            Participants = new Dictionary<ulong, RaidParticipant>();

            //LoadTestData();
        }
        public ulong Id { get; set; }
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


        public ulong? ChannelId { get; set; }
        private DiscordChannel channel;

        public async Task<DiscordChannel> GetChannel()
        {
            if (channel == null && ChannelId.HasValue)
            {
                channel = await Program.DiscordClient.GetChannelAsync(ChannelId.Value);
            }

            return channel;
        }

        public void SetChannel(DiscordChannel _channel)
        {
            channel = _channel;
        }

        public string Title { get; set; }
        public Dictionary<ulong, RaidParticipant> Participants { get; set; }
        public DateTime EventStart { get; set; }
        public bool Notified { get; set; }
        public bool Expired { get; set; }
        public int TankLimit { get; set; }
        public int DPSLimit { get; set; }
        public int HealerLimit { get; set; }

        public string RenderParticipants()
        {
            StringBuilder builder = new();

            Queue<RaidParticipant> tanks = new();
            Queue<RaidParticipant> melees = new();
            Queue<RaidParticipant> healers = new();
            Queue<RaidParticipant> ranged = new();
            Queue<RaidParticipant> magicals = new();

            foreach (var item in Participants.OrderBy(o => o.Value.Role))
            {
                if (Utils.IsTank(item.Value.Role))
                    tanks.Enqueue(item.Value);
                if (Utils.IsMeleeDPS(item.Value.Role))
                    melees.Enqueue(item.Value);
                if (Utils.IsHealer(item.Value.Role))
                    healers.Enqueue(item.Value);
                if (Utils.IsRangedDPS(item.Value.Role))
                    ranged.Enqueue(item.Value);
                if (Utils.IsMagicDPS(item.Value.Role))
                    magicals.Enqueue(item.Value);
            }

            int columnLimit = 60;
            string TankColumn = $" Tanks {tanks.Count}/{TankLimit}";

            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":TANK:"));
            builder.Append(TankColumn);

            for (int i = 0; i < columnLimit - Utils.CountSpaces(TankColumn) - 7; i++)
                builder.Append(' ');

            string DPSColumn = $" DPS {melees.Count + ranged.Count + magicals.Count}/{DPSLimit}";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":DPS:"));
            builder.Append(DPSColumn);
            for (int i = 0; i < columnLimit - Utils.CountSpaces(DPSColumn) - 8; i++)
                builder.Append(' ');

            string HealerColumn = $" Healers {healers.Count}/{HealerLimit}";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":HEALER:"));
            builder.Append(HealerColumn);
            builder.Append("\n\n");

            TankColumn = $" Tank ({tanks.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":TANK:"));
            builder.Append(TankColumn);
            for (int i = 0; i < columnLimit - Utils.CountSpaces(TankColumn) - 7; i++)
                builder.Append(' ');

            DPSColumn = $" Melee ({melees.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":MELEE:"));
            builder.Append(DPSColumn);
            for (int i = 0; i < columnLimit - Utils.CountSpaces(DPSColumn) - 8; i++)
                builder.Append(' ');

            HealerColumn = $" Healer ({healers.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":HEALER:"));
            builder.Append(HealerColumn);
            builder.Append('\n');

            RaidParticipant participant;

            List<RaidParticipant> rowToDraw = new();

            while (tanks.Count > 0 || melees.Count > 0 || healers.Count > 0)
            {
                if (tanks.Count > 0)
                    rowToDraw.Add(tanks.Dequeue());
                else
                    rowToDraw.Add(null);

                if (melees.Count > 0)
                    rowToDraw.Add(melees.Dequeue());
                else
                    rowToDraw.Add(null);
                if (healers.Count > 0)
                    rowToDraw.Add(healers.Dequeue());
                else
                    rowToDraw.Add(null);
            }

            int counter = 1;
            foreach (var p in rowToDraw)
            {
                if (p == null)
                {
                    for (int i = 0; i < columnLimit; i++)
                        builder.Append(' ');

                    if (counter++ % 3 == 0)
                        builder.Append('\n');

                    continue;
                }

                string Column = $" {p.Username}";
                builder.Append(DiscordEmoji.FromName(Program.DiscordClient, string.Concat(":", p.Role, ":")));
                builder.Append(Column);
                for (int i = 0; i < columnLimit - Utils.CountSpaces(p.Username) - 8; i++)
                    builder.Append(' ');

                if (counter++ % 3 == 0)
                    builder.Append('\n');
            }

            builder.Append('\n');

            string RangedColumn = $" Ranged ({ranged.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":RANGED:"));
            builder.Append(RangedColumn);
            for (int i = 0; i < columnLimit - Utils.CountSpaces(RangedColumn) - 7; i++)
                builder.Append(' ');

            string MagicColumn = $" Magical ({magicals.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":MAGICAL:"));
            builder.Append(MagicColumn);
            builder.Append('\n');

            rowToDraw.Clear();

            while (ranged.Count > 0 || magicals.Count > 0)
            {
                if (ranged.Count > 0)
                    rowToDraw.Add(ranged.Dequeue());
                else
                    rowToDraw.Add(null);

                if (magicals.Count > 0)
                    rowToDraw.Add(magicals.Dequeue());
                else
                    rowToDraw.Add(null);
            }

            counter = 1;
            foreach (var p in rowToDraw)
            {
                if (p == null)
                {
                    for (int i = 0; i < columnLimit; i++)
                        builder.Append(' ');

                    if (counter++ % 2 == 0)
                        builder.Append('\n');

                    continue;
                }

                string Column = $"{DiscordEmoji.FromName(Program.DiscordClient, string.Concat(":", p.Role, ":"))} {p.Username}";
                builder.Append(Column);
                for (int i = 0; i < columnLimit - Utils.CountSpaces(p.Username) - 8; i++)
                    builder.Append(' ');

                if (counter++ % 2 == 0)
                    builder.Append('\n');
            }

            return builder.ToString();
        }

        public string CreateMessage()
        {
            string message;
            string eventStart = EventStart.ToString("dd/MM/yyyy HH:mm:ss");

            if (!Expired)
            {
                message = $"The raid {Title} is starting at {eventStart} ST";
            }
            else
            {
                message = $"{DiscordEmoji.FromName(Program.DiscordClient, ":raidfinished:")} The raid {Title} has started ~~{eventStart} ST~~";
            }

            return $"id: [{Id}]\n{RenderParticipants()}\n{message}";
        }

        public async Task<DiscordMessage> UpdateMessage()
        {
            var message = await GetMessage();
            if (message != null)
            {
                return await message.ModifyAsync(CreateMessage());
            }
            return null;
        }

        public async Task DeleteMessage()
        {
            var message = await GetMessage();

            if (message != null)
                await message.DeleteAsync();
        }


        public async void ReactionAdded(DiscordClient s, MessageReactionAddEventArgs e, DiscordMessage message)
        {
            DiscordEmoji emojiToRemove = null;

            lock (RaidStorage.eventLock)
            {
                DiscordMember member = null;
                string NickName = e.User.Username;

                if (e.User.Presence == null)
                    member = null;
                else if (e.User.Presence.Guild != null)
                    e.User.Presence.Guild.Members.TryGetValue(e.User.Id, out member);

                if (!Enum.TryParse(typeof(Job), e.Emoji.Name.Trim(':'), out object job))
                    return;

                if (member != null && !string.IsNullOrEmpty(member.Nickname))
                    NickName = member.Nickname;

                if (Participants.ContainsKey(e.User.Id))
                {
                    var prevParticipation = Participants[e.User.Id];

                    emojiToRemove = DiscordEmoji.FromName(s, string.Concat(":", prevParticipation.Role.ToString(), ":"));

                    Participants.Remove(e.User.Id);
                }

                Participants.Add(e.User.Id, new RaidParticipant
                {
                    Role = (Job)job,
                    Username = NickName
                });
            }

            if (emojiToRemove != null && message != null)
                await message.DeleteReactionAsync(emojiToRemove, e.User);

            await message.ModifyAsync(CreateMessage());
        }

        public async void ReactionRemoved(DiscordClient s, MessageReactionRemoveEventArgs e)
        {

        }
    }
}

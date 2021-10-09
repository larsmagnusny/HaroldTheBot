﻿using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace HaroldTheBot
{
    public enum Job
    {
        ARC, // Archer
        GLA, // Gladiator
        LNC, // Lancer
        MRD, // Marauder
        PGL, // Pugilist
        ACN, // Arcanist
        CNJ, // Conjurer
        THM, // Thaumaturge
        ROG, // Rogue
        BRD, // Bard
        DRG, // Dragoon
        MNK, // Monk
        PLD, // Paladin
        WAR, // Warrior
        BLM, // Black
        WHM, // White Mage
        SCH, // Scholar
        SMN, // Summoner
        NIN, // Ninja Icon
        AST, // Astrologian
        DRK, // Dark Knight
        MCH, // Machinist
        RDM, // Red Mage
        SAM, // Samurai
        BLU, // Blue Mage
        GNB, // Gunbreaker
        DNC, // Dancer
    }

    public class RaidParticipant
    {
        public string Username { get; set; }
        public Job Role { get; set; }
    }

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
        public Guid Id { get; set; }
        public ulong? MessageId { get; set; }
        public DiscordMessage Message { get; set; }
        public ulong? ChannelId { get; set; }
        public DiscordChannel Channel { get; set; }
        public string Title { get; set; }
        public Dictionary<ulong, RaidParticipant> Participants { get; set; }
        public DateTime EventStart { get; set; }
        public int TankLimit { get; set; }
        public int DPSLimit { get; set; }
        public int HealerLimit { get; set; }

        public void LoadTestData()
        {
            Participants.Clear();

            Participants.Add(0, new RaidParticipant
            {
                Role = Job.WAR,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(1, new RaidParticipant
            {
                Role = Job.MNK,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(2, new RaidParticipant
            {
                Role = Job.WHM,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(3, new RaidParticipant
            {
                Role = Job.ARC,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(4, new RaidParticipant
            {
                Role = Job.BLM,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(5, new RaidParticipant
            {
                Role = Job.WAR,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(6, new RaidParticipant
            {
                Role = Job.MNK,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(7, new RaidParticipant
            {
                Role = Job.WHM,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(8, new RaidParticipant
            {
                Role = Job.ARC,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(9, new RaidParticipant
            {
                Role = Job.BLM,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(10, new RaidParticipant
            {
                Role = Job.WAR,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(11, new RaidParticipant
            {
                Role = Job.MNK,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(12, new RaidParticipant
            {
                Role = Job.WHM,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(13, new RaidParticipant
            {
                Role = Job.ARC,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(14, new RaidParticipant
            {
                Role = Job.BLM,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(15, new RaidParticipant
            {
                Role = Job.WAR,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(16, new RaidParticipant
            {
                Role = Job.MNK,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(17, new RaidParticipant
            {
                Role = Job.WHM,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(18, new RaidParticipant
            {
                Role = Job.ARC,
                Username = Utils.GenerateRandomAlphanumericString()
            });

            Participants.Add(19, new RaidParticipant
            {
                Role = Job.BLM,
                Username = Utils.GenerateRandomAlphanumericString()
            });
        }

        public string RenderParticipants()
        {
            StringBuilder builder = new StringBuilder();

            Queue<RaidParticipant> tanks = new Queue<RaidParticipant>();
            Queue<RaidParticipant> melees = new Queue<RaidParticipant>();
            Queue<RaidParticipant> healers = new Queue<RaidParticipant>();
            Queue<RaidParticipant> ranged = new Queue<RaidParticipant>();
            Queue<RaidParticipant> magicals = new Queue<RaidParticipant>();

            foreach(var item in Participants.OrderBy(o => o.Value.Role))
            {
                if (Utils.isTank(item.Value.Role))
                    tanks.Enqueue(item.Value);
                if (Utils.isMeleeDPS(item.Value.Role))
                    melees.Enqueue(item.Value);
                if (Utils.isHealer(item.Value.Role))
                    healers.Enqueue(item.Value);
                if (Utils.isRangedDPS(item.Value.Role))
                    ranged.Enqueue(item.Value);
                if (Utils.isMagicDPS(item.Value.Role))
                    magicals.Enqueue(item.Value);
            }

            int columnLimit = 60;
            string TankColumn = $" Tanks {tanks.Count}/{TankLimit}";

            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":TANK:"));
            builder.Append(TankColumn);

            for (int i = 0; i < columnLimit - Utils.countSpaces(TankColumn) - 7; i++)
                builder.Append(" ");

            string DPSColumn = $" DPS {melees.Count + ranged.Count + magicals.Count}/{DPSLimit}";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":DPS:"));
            builder.Append(DPSColumn);
            for (int i = 0; i < columnLimit - Utils.countSpaces(DPSColumn) - 8; i++)
                builder.Append(" ");

            string HealerColumn = $" Healers {healers.Count}/{HealerLimit}";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":HEALER:"));
            builder.Append(HealerColumn);
            builder.Append("\n\n");

            TankColumn = $" Tank ({tanks.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":TANK:"));
            builder.Append(TankColumn);
            for (int i = 0; i < columnLimit - Utils.countSpaces(TankColumn) - 7; i++)
                builder.Append(" ");

            DPSColumn = $" Melee ({melees.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":MELEE:"));
            builder.Append(DPSColumn);
            for (int i = 0; i < columnLimit - Utils.countSpaces(DPSColumn) - 8; i++)
                builder.Append(" ");

            HealerColumn = $" Healer ({healers.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":HEALER:"));
            builder.Append(HealerColumn);
            builder.Append("\n");

            RaidParticipant participant;

            List<RaidParticipant> rowToDraw = new List<RaidParticipant>();

            while(tanks.Count > 0 || melees.Count > 0 || healers.Count > 0)
            {
                if (tanks.Count > 0)
                    rowToDraw.Add(tanks.Dequeue());
                else
                    rowToDraw.Add(null);

                if (melees.Count > 0)
                    rowToDraw.Add(melees.Dequeue());
                else
                    rowToDraw.Add(null);
                if(healers.Count > 0)
                    rowToDraw.Add(healers.Dequeue());
                else
                    rowToDraw.Add(null);
            }

            int counter = 1;
            foreach(var p in rowToDraw)
            {
                if(p == null)
                {
                    for (int i = 0; i < columnLimit; i++)
                        builder.Append(" ");

                    if (counter++ % 3 == 0)
                        builder.Append("\n");

                    continue;
                }

                string Column = $" {p.Username}";
                builder.Append(DiscordEmoji.FromName(Program.DiscordClient, string.Concat(":", p.Role, ":")));
                builder.Append(Column);
                for (int i = 0; i < columnLimit - Utils.countSpaces(p.Username) - 8; i++)
                    builder.Append(" ");

                if (counter++ % 3 == 0)
                    builder.Append("\n");
            }

            builder.Append("\n");

            string RangedColumn = $" Ranged ({ranged.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":RANGED:"));
            builder.Append(RangedColumn);
            for (int i = 0; i < columnLimit - Utils.countSpaces(RangedColumn) - 7; i++)
                builder.Append(" ");

            string MagicColumn = $" Magical ({magicals.Count})";
            builder.Append(DiscordEmoji.FromName(Program.DiscordClient, ":MAGICAL:"));
            builder.Append(MagicColumn);
            builder.Append("\n");

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
                        builder.Append(" ");

                    if (counter++ % 2 == 0)
                        builder.Append("\n");

                    continue;
                }

                string Column = $"{DiscordEmoji.FromName(Program.DiscordClient, string.Concat(":", p.Role, ":"))} {p.Username}";
                builder.Append(Column);
                for (int i = 0; i < columnLimit - Utils.countSpaces(p.Username) - 8; i++)
                    builder.Append(" ");

                if (counter++ % 2 == 0)
                    builder.Append("\n");
            }

            return builder.ToString();
        }

        public string CreateMessage()
        {
            return $"id: [{Id}]\n{RenderParticipants()}\nThe raid {Title} is starting at {EventStart.ToString("dd/MM/yyyy HH:mm:ss")} ";
        }

        public async Task<DiscordMessage> UpdateMessage()
        {
            if (Message != null)
            {
                return await Message.ModifyAsync(CreateMessage());
            }
            return null;
        }

        public async Task DeleteMessage()
        {
            await Message.DeleteAsync();
        }
    }

    public static class RaidStorage
    {
        public static object eventLock = new object(); 
        private static Dictionary<Guid, RaidEvent> RaidEvents = new Dictionary<Guid, RaidEvent>();
        

        public static RaidEvent AddRaid(string title, DateTime eventStart)
        {
            var guid = Guid.NewGuid();
            var raidEvent = new RaidEvent
            {
                Id = guid,
                Title = title,
                EventStart = eventStart,
                Message = null
            };

            lock (eventLock)
            {
                RaidEvents.Add(guid, raidEvent);
            }

            return raidEvent;
        }

        public static RaidEvent GetRaid(Guid guid)
        {
            lock (eventLock)
            {
                if (!RaidEvents.ContainsKey(guid))
                    return null;

                return RaidEvents[guid];
            }
        }

        public static bool RemoveRaid(Guid guid)
        {
            lock (eventLock)
            {
                if (RaidEvents.ContainsKey(guid))
                {
                    var ev = RaidEvents[guid];
                    ev.DeleteMessage();
                }
                return RaidEvents.Remove(guid);
            }
        }

        public static void SaveStorage()
        {
            var fStream = File.Open("storage.bin", FileMode.OpenOrCreate);

            byte[] buffer;
            lock (eventLock)
            {
                buffer = BitConverter.GetBytes(RaidEvents.Count);
                fStream.Write(buffer);
                foreach (var ev in RaidEvents)
                {
                    var guidStr = ev.Key.ToString();
                    buffer = BitConverter.GetBytes(guidStr.Length);
                    fStream.Write(buffer);

                    buffer = Encoding.UTF8.GetBytes(guidStr);
                    fStream.Write(buffer);

                    buffer = BitConverter.GetBytes(ev.Value.Title.Length);
                    fStream.Write(buffer);

                    buffer = Encoding.UTF8.GetBytes(ev.Value.Title);
                    fStream.Write(buffer);

                    buffer = BitConverter.GetBytes(ev.Value.MessageId ?? 0);
                    fStream.Write(buffer);

                    buffer = BitConverter.GetBytes(ev.Value.ChannelId ?? 0);
                    fStream.Write(buffer);

                    buffer = BitConverter.GetBytes(ev.Value.EventStart.ToBinary());
                    fStream.Write(buffer);

                    buffer = BitConverter.GetBytes(ev.Value.Participants.Count);
                    fStream.Write(buffer);

                    foreach (var participant in ev.Value.Participants)
                    {
                        buffer = BitConverter.GetBytes(participant.Key);
                        fStream.Write(buffer);

                        buffer = BitConverter.GetBytes((int)participant.Value.Role);
                        fStream.Write(buffer);

                        buffer = BitConverter.GetBytes(participant.Value.Username.Length);
                        fStream.Write(buffer);

                        buffer = Encoding.UTF8.GetBytes(participant.Value.Username);
                        fStream.Write(buffer);
                    }
                }
            }

            fStream.Close();
        }

        public static void LoadStorage()
        {
            var fStream = File.Open("storage.bin", FileMode.OpenOrCreate);

            byte[] intBuffer = new byte[4];
            byte[] longBuffer = new byte[8];
            byte[] strBuffer;
            int len;
            ulong ulo;
            long lo;
            lock (eventLock)
            {
                fStream.Read(intBuffer, 0, 4);
                int numEvents = BitConverter.ToInt32(intBuffer);

                for(int i = 0; i < numEvents; i++)
                {
                    var ev = new RaidEvent();

                    fStream.Read(intBuffer, 0, 4);
                    len = BitConverter.ToInt32(intBuffer);

                    strBuffer = new byte[len];
                    fStream.Read(strBuffer, 0, len);

                    ev.Id = Guid.Parse(Encoding.UTF8.GetString(strBuffer));

                    fStream.Read(intBuffer, 0, 4);
                    len = BitConverter.ToInt32(intBuffer);

                    strBuffer = new byte[len];
                    fStream.Read(strBuffer, 0, len);
                    ev.Title = Encoding.UTF8.GetString(strBuffer);

                    fStream.Read(longBuffer, 0, 8);
                    ulo = BitConverter.ToUInt64(longBuffer);
                    ev.MessageId = ulo != 0 ? ulo : null;

                    fStream.Read(longBuffer, 0, 8);
                    ulo = BitConverter.ToUInt64(longBuffer);
                    ev.ChannelId = ulo != 0 ? ulo : null;

                    fStream.Read(longBuffer, 0, 8);
                    lo = BitConverter.ToInt64(longBuffer);
                    ev.EventStart = DateTime.FromBinary(lo);

                    fStream.Read(intBuffer, 0, 4);

                    int numParticipants = BitConverter.ToInt32(intBuffer);

                    for(int j = 0; j < numParticipants; j++)
                    {
                        var nP = new RaidParticipant();
                        fStream.Read(longBuffer, 0, 8);
                        ulo = BitConverter.ToUInt64(longBuffer);

                        fStream.Read(intBuffer, 0, 4);
                        nP.Role = (Job)BitConverter.ToInt32(intBuffer);

                        fStream.Read(intBuffer, 0, 4);
                        len = BitConverter.ToInt32(intBuffer);
                        strBuffer = new byte[len];
                        fStream.Read(strBuffer, 0, len);
                        nP.Username = Encoding.UTF8.GetString(strBuffer);

                        if(!ev.Participants.ContainsKey(ulo))
                            ev.Participants.Add(ulo, nP);
                    }

                    RaidEvents.Add(ev.Id, ev);
                }
            }

            fStream.Close();
        }
    }

    public static class MessageMonitorer
    {
        public static Dictionary<string, StringComparison> StringBlacklist = new Dictionary<string, StringComparison>()
        {
            { "WoW", StringComparison.Ordinal },
            { "World of Warcraft", StringComparison.OrdinalIgnoreCase }
        };

        public static async void ReactionRemoved(DiscordClient s, MessageReactionRemoveEventArgs e)
        {
            var message = e.Message;
            if(message.Content == null)
            {
                message = await e.Channel.GetMessageAsync(e.Message.Id);
            }

            int guidIndex = message.Content.IndexOf("id: [");
            int guidEnd = message.Content.IndexOf("]", guidIndex + 5);

            if (guidIndex == -1 || guidEnd == -1)
                return;

            string guidStr = message.Content.Substring(guidIndex + 5, guidEnd - guidIndex - 5);

            var guid = Guid.Parse(guidStr);

            RaidEvent ev;

            lock (RaidStorage.eventLock)
            {
                ev = RaidStorage.GetRaid(guid);
                ev.Message = message;
                DiscordMember member;

                e.User.Presence.Guild.Members.TryGetValue(e.User.Id, out member);

                string NickName = e.User.Username;

                if (!string.IsNullOrEmpty(member.Nickname))
                    NickName = member.Nickname;

                if (member != null)
                {
                    if (!ev.Participants.ContainsKey(e.User.Id))
                        return;

                    RaidParticipant participant = ev.Participants[e.User.Id];

                    if(participant.Role.ToString() == e.Emoji.Name.Trim(':'))
                        ev.Participants.Remove(e.User.Id);
                }
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

            int guidIndex = message.Content.IndexOf("id: [");
            int guidEnd = message.Content.IndexOf("]", guidIndex + 5);

            if (guidIndex == -1 || guidEnd == -1)
                return;

            string guidStr = message.Content.Substring(guidIndex + 5, guidEnd - guidIndex - 5);

            var guid = Guid.Parse(guidStr);

            RaidEvent ev;

            DiscordEmoji emojiToRemove = null;
            
            lock (RaidStorage.eventLock)
            {
                ev = RaidStorage.GetRaid(guid);
                ev.Message = message;

                DiscordMember member;

                e.User.Presence.Guild.Members.TryGetValue(e.User.Id, out member);

                if (member != null)
                {
                    object job;

                    if (!Enum.TryParse(typeof(Job), e.Emoji.Name.Trim(':'), out job))
                        return;

                    string NickName = e.User.Username;

                    if (!string.IsNullOrEmpty(member.Nickname))
                        NickName = member.Nickname;

                    if (ev.Participants.ContainsKey(e.User.Id))
                    {
                        var prevParticipation = ev.Participants[e.User.Id];

                        emojiToRemove = DiscordEmoji.FromName(Program.DiscordClient, string.Concat(":", prevParticipation.Role.ToString(), ":"));

                        ev.Participants.Remove(e.User.Id);
                    }

                    ev.Participants.Add(e.User.Id, new RaidParticipant
                    {
                        Role = (Job)job,
                        Username = NickName
                    });
                }
            }

            if(emojiToRemove != null)
                await ev.Message.DeleteReactionAsync(emojiToRemove, e.User);

            await e.Message.ModifyAsync(ev.CreateMessage());
        }

        public static async void MessageCreated(DiscordClient s, MessageCreateEventArgs e)
        {
            if (e.Message.Author.Username == "HaroldTheBot")
                return;

            bool triggered = false;
            string triggerStr = "We don't talk about that in here";
            foreach (var item in StringBlacklist) {
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
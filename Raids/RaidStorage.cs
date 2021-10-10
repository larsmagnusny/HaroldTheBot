using DSharpPlus;
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

namespace HaroldTheBot.Raids
{
    public static class RaidStorage
    {
        public static object eventLock = new(); 
        private static Dictionary<ulong, RaidEvent> RaidEvents = new();
        
        public static RaidEvent AddRaid(ulong messageId, string title, DateTime eventStart)
        {
            var raidEvent = new RaidEvent
            {
                Id = messageId,
                Title = title,
                EventStart = eventStart
            };

            lock (eventLock)
            {
                RaidEvents.Add(messageId, raidEvent);
            }

            return raidEvent;
        }

        public static RaidEvent GetRaid(ulong messageId)
        {
            lock (eventLock)
            {
                if (!RaidEvents.ContainsKey(messageId))
                    return null;

                return RaidEvents[messageId];
            }
        }

        public static IEnumerable<RaidEvent> GetRaids()
        {
            return RaidEvents.Values;
        }

        public static bool RemoveRaid(ulong messageId)
        {
            lock (eventLock)
            {
                if (RaidEvents.ContainsKey(messageId))
                {
                    var ev = RaidEvents[messageId];
                    ev.DeleteMessage();
                }
                return RaidEvents.Remove(messageId);
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
                    buffer = BitConverter.GetBytes(ev.Value.Id);
                    fStream.Write(buffer);

                    buffer = BitConverter.GetBytes(ev.Value.Notified);
                    fStream.Write(buffer);

                    buffer = BitConverter.GetBytes(ev.Value.Expired);
                    fStream.Write(buffer);

                    buffer = BitConverter.GetBytes(ev.Value.Title.Length);
                    fStream.Write(buffer);

                    buffer = Encoding.UTF8.GetBytes(ev.Value.Title);
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
            byte[] boolBuffer = new byte[1];
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

                    fStream.Read(longBuffer, 0, 8);
                    ev.Id = BitConverter.ToUInt64(longBuffer);

                    fStream.Read(boolBuffer, 0, 1);
                    ev.Notified = BitConverter.ToBoolean(boolBuffer);

                    fStream.Read(boolBuffer, 0, 1);
                    ev.Expired = BitConverter.ToBoolean(boolBuffer);

                    fStream.Read(intBuffer, 0, 4);
                    len = BitConverter.ToInt32(intBuffer);

                    strBuffer = new byte[len];
                    fStream.Read(strBuffer, 0, len);
                    ev.Title = Encoding.UTF8.GetString(strBuffer);

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
}

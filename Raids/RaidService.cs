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
using HaroldTheBot.Data;

namespace HaroldTheBot.Raids
{
    public class RaidService : IRaidService
    {
        private readonly IRaidRepository _raidRepository;
        public RaidService(IRaidRepository raidRepository)
        {
            _raidRepository = raidRepository;
        }
        
        public RaidEvent AddRaid(ulong messageId, string title, DateTime eventStart)
        {
            var raidEvent = new RaidEvent
            {
                Id = messageId,
                Title = title,
                EventStart = eventStart
            };

            _raidRepository.AddRaidEvent(new Data.Entities.RaidEvent()
            {
                Id = raidEvent.Id,
                ChannelId = raidEvent.ChannelId.Value,
                Title = raidEvent.Title,
                EventStart = eventStart,
                Notified = raidEvent.Notified,
                Expired = raidEvent.Expired,
                TankLimit = raidEvent.TankLimit,
                DPSLimit = raidEvent.DPSLimit,
                HealerLimit = raidEvent.HealerLimit
            });

            return raidEvent;
        }

        public RaidEvent GetRaid(ulong messageId)
        {
            var ev = _raidRepository.GetRaidEvent(messageId);

            if (ev == null)
                return null;

            return new RaidEvent
            {
                Id = messageId,
                ChannelId = ev.ChannelId,
                Title = ev.Title,
                EventStart = ev.EventStart,
                Notified = ev.Notified,
                Expired = ev.Expired,
                TankLimit = ev.TankLimit,
                DPSLimit = ev.DPSLimit,
                HealerLimit = ev.HealerLimit
            };
        }

        public IEnumerable<RaidEvent> GetRaids()
        {
            return _raidRepository.GetAllRaidEvents().Select(x =>
                new RaidEvent
                {
                    Id = x.Id,
                    ChannelId = x.ChannelId,
                    Title = x.Title,
                    EventStart = x.EventStart,
                    Notified = x.Notified,
                    Expired = x.Expired,
                    TankLimit = x.TankLimit,
                    DPSLimit = x.DPSLimit,
                    HealerLimit = x.HealerLimit
                }
            );
        }

        public bool RemoveRaid(ulong messageId)
        {
            return _raidRepository.RemoveRaidEvent(messageId);
        }
    }
}

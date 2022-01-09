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

        public void AddParticipant(ulong messageId, RaidParticipant participant)
        {
            _raidRepository.AddParticipant(new Data.Entities.RaidParticipant
            {
                RaidEventId = messageId,
                JobId = (int)participant.Role,
                UserId = participant.UserId,
                Username = participant.Username
            });
        }

        public void AddRaid(RaidEvent ev)
        {
            _raidRepository.AddRaidEvent(new Data.Entities.RaidEvent()
            {
                Id = ev.Id,
                ChannelId = ev.ChannelId.Value,
                Title = ev.Title,
                EventStart = ev.EventStart,
                Notified = ev.Notified,
                Expired = ev.Expired,
                TankLimit = ev.TankLimit,
                DPSLimit = ev.DPSLimit,
                HealerLimit = ev.HealerLimit
            });
        }

        public RaidParticipant GetParticipant(ulong messageId, ulong userId)
        {
            var participant = _raidRepository.GetParticipant(messageId, userId);

            if (participant == null)
                return null;

            return new RaidParticipant
            {
                UserId = participant.UserId,
                Role = (Job)participant.JobId,
                Username = participant.Username
            };
        }

        public IEnumerable<RaidParticipant> GetParticipants(ulong messageId)
        {
            return _raidRepository.GetParticipants(messageId).Select(o => new RaidParticipant
            {
                Role = o.Job != null ? (Job)o.Job.Id : Job.ACN,
                Username = o.Username
            }).ToList();
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
                    TankLimit = x.TankLimit,
                    DPSLimit = x.DPSLimit,
                    HealerLimit = x.HealerLimit
                }
            );
        }

        public bool HasParticipant(ulong messageId, ulong userId)
        {
            return _raidRepository.HasParticipant(messageId, userId);
        }

        public bool RemoveParticipant(ulong messageId, ulong userId)
        {
            return _raidRepository.RemoveParticipant(messageId, userId);
        }

        public bool RemoveRaid(ulong messageId)
        {
            return _raidRepository.RemoveRaidEvent(messageId);
        }

        public void SetRaidNotified(ulong messageId)
        {
            _raidRepository.SetRaidNotified(messageId);
        }
    }
}

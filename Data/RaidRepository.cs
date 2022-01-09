using HaroldTheBot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Data
{
    public class RaidRepository : IRaidRepository
    {
        private readonly HaroldDbContext _db;

        public RaidRepository(HaroldDbContext db)
        {
            _db = db;
        }

        public void AddParticipant(RaidParticipant participant)
        {
            _db.RaidParticipants.Add(participant);
            _db.SaveChanges();
        }

        public void AddRaidEvent(RaidEvent ev)
        {
            _db.RaidEvents.Add(ev);
            _db.SaveChanges();
        }

        public IEnumerable<RaidEvent> GetAllRaidEvents()
        {
            return _db.RaidEvents;
        }

        public RaidParticipant GetParticipant(ulong raidId, string username)
        {
            return _db.RaidParticipants
                .Include(o => o.Job)
                .FirstOrDefault(o => o.RaidEventId == raidId && o.Username == username);
        }

        public RaidParticipant GetParticipant(ulong raidId, ulong userId)
        {
            return _db.RaidParticipants
                .Include(o => o.Job)
                .FirstOrDefault(o => o.RaidEventId == raidId && o.UserId == userId);
        }

        public IEnumerable<RaidParticipant> GetParticipants(ulong raidId)
        {
            return _db.RaidParticipants
                .Include(o => o.Job)
                .Where(o => o.RaidEventId == raidId);
        }

        public RaidEvent GetRaidEvent(ulong raidId)
        {
            return _db.RaidEvents.FirstOrDefault(o => o.Id == raidId);
        }

        public bool HasParticipant(ulong raidId, ulong userId)
        {
            return _db.RaidParticipants.Where(o => o.RaidEventId == raidId).Any(o => o.UserId == userId);
        }

        public bool RemoveParticipant(ulong raidId, string username)
        {
            var participant = GetParticipant(raidId, username);

            if (participant == null)
                return false;

            _db.RaidParticipants.Remove(participant);
            _db.SaveChanges();

            return true;
        }

        public bool RemoveParticipant(ulong raidId, ulong userId)
        {
            var participant = GetParticipant(raidId, userId);

            if (participant == null)
                return false;

            _db.RaidParticipants.Remove(participant);
            _db.SaveChanges();

            return true;
        }

        public bool RemoveRaidEvent(ulong raidId)
        {
            var raid = GetRaidEvent(raidId);

            if (raid == null)
                return false;

            _db.RaidEvents.Remove(raid);
            _db.SaveChanges();

            return true;
        }

        public void SetRaidNotified(ulong raidId)
        {
            var raid = GetRaidEvent(raidId);
            raid.Notified = true;
            _db.SaveChanges();
        }
    }
}

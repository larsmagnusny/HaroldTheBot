using HaroldTheBot.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Data
{
    public interface IRaidRepository
    {
        RaidEvent GetRaidEvent(ulong raidId);
        IEnumerable<RaidEvent> GetAllRaidEvents();
        RaidParticipant GetParticipant(ulong raidId, string username);
        RaidParticipant GetParticipant(ulong raidId, ulong userId);
        IEnumerable<RaidParticipant> GetParticipants(ulong raidId);

        void SetRaidNotified(ulong raidId);
        void AddRaidEvent(RaidEvent ev);
        bool RemoveRaidEvent(ulong raidId);


        void AddParticipant(RaidParticipant participant);
        bool RemoveParticipant(ulong raidId, string username);
        bool RemoveParticipant(ulong raidId, ulong userId);
        bool HasParticipant(ulong raidId, ulong userId);
    }
}

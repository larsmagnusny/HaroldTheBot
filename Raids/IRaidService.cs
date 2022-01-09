using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Raids
{
    public interface IRaidService
    {
        void AddRaid(RaidEvent ev);
        RaidEvent GetRaid(ulong messageId);
        IEnumerable<RaidEvent> GetRaids();
        bool RemoveRaid(ulong messageId);
        void SetRaidNotified(ulong messageId);

        IEnumerable<RaidParticipant> GetParticipants(ulong messageId);
        RaidParticipant GetParticipant(ulong messageId, ulong userId);
        bool HasParticipant(ulong messageId, ulong userId);
        bool RemoveParticipant(ulong messageId, ulong userId);
        void AddParticipant(ulong messageId, RaidParticipant participant);
    }
}

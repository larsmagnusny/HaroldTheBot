using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Raids
{
    public interface IRaidService
    {
        RaidEvent AddRaid(ulong messageId, string title, DateTime eventStart);
        RaidEvent GetRaid(ulong messageId);
        IEnumerable<RaidEvent> GetRaids();
        bool RemoveRaid(ulong messageId);
    }
}

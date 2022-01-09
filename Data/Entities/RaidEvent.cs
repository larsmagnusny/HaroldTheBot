using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Data.Entities
{
    public class RaidEvent
    {
        public ulong Id { get; set; }
        public ulong ChannelId { get; set; }
        public string Title { get; set; }
        public DateTime EventStart { get; set; }
        public bool Notified { get; set; }
        public bool Expired { get; set; }
        public int TankLimit { get; set; }
        public int DPSLimit { get; set; }
        public int HealerLimit { get; set; }

        public ICollection<RaidParticipant> Participants { get; set; }
    }
}

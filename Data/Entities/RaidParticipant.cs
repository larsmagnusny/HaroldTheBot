using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Data.Entities
{
    public class RaidParticipant
    {
        [ForeignKey("RaidEvents_RaidEventId")]
        public ulong RaidEventId { get; set; }
        public ulong UserId { get; set; }

        [ForeignKey("Jobs_JobId")]
        public int JobId { get; set; }

        public string Username { get; set; }
        public Job Job { get; set; }
        public RaidEvent RaidEvent { get; set; }
    }
}

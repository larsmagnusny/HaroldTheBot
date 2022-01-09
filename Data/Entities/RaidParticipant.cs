using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Data.Entities
{
    public class RaidParticipant
    {
        public ulong RaidEventId { get; set; }
        public int JobId { get; set; }

        public string Username { get; set; }
        public Job Role { get; set; }
        public RaidEvent RaidEvent { get; set; }
    }
}

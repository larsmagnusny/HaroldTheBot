using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public class VoteOption
    {
        public Guid Id { get; set; }
        public ulong MessageId { get; set; }
        public string Title { get; set; }
    }

    public class Vote
    {
        public string Title { get; set; }
        public Dictionary<int, VoteOption> Options { get; set; }
        public Dictionary<int, UserVote> UserVotes { get; set; }
    }
}

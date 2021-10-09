using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public static class VoteStorage
    {
        // Key is the message id
        private static Dictionary<Guid, Vote> Votes = new();

        public static void SaveVotes()
        {

        }

        public static void LoadVotes()
        {

        }
    }
}

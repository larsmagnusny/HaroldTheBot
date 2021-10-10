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
        public static object voteLock = new();
        private static Dictionary<ulong, VoteEvent> Votes = new();

        public static bool AddVote(VoteEvent v)
        {
            lock (voteLock)
            {
                if (Votes.ContainsKey(v.Id))
                    return false;

                Votes.Add(v.Id, v);
            }
            return true;
        }

        public static VoteEvent GetVote(ulong id)
        {
            lock (voteLock)
            {
                if (Votes.ContainsKey(id))
                    return Votes[id];
            }

            return null;
        }

        public static void SaveVotes()
        {

        }

        public static void LoadVotes()
        {

        }
    }
}

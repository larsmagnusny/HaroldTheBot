using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public class VoteOption
    {
        public string Title { get; set; }
    }

    public class VoteEvent
    {
        public VoteEvent()
        {
            UserVotes = new List<UserVote>();
        }

        public ulong Id { get; set; }
        public string Title { get; set; }
        public VoteOption[] Options { get; set; }
        public List<UserVote> UserVotes { get; set; }

        public string GetMessage()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"id: [{Id}]\n");
            builder.Append(Title);
            builder.Append("\n\n");

            Dictionary<int, int> voteCounter = new Dictionary<int, int>();

            for(int i = 0; i < UserVotes.Count; i++)
            {
                if(UserVotes[i].OptionId < Options.Length && UserVotes[i].OptionId >= 0)
                {
                    if (voteCounter.ContainsKey(UserVotes[i].OptionId))
                        voteCounter[UserVotes[i].OptionId]++;
                    else
                        voteCounter[UserVotes[i].OptionId] = 1;
                }
            }

            for(int i = 0; i < Options.Length; i++)
            {
                int numVotes = voteCounter.ContainsKey(i) ? voteCounter[i] : 0;

                builder.Append(Options[i].Title);
                builder.Append($"      [{numVotes}]\n");
            }

            return builder.ToString();
        }
    }
}

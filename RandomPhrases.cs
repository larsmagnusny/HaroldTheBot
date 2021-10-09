using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public static class RandomPhrases
    {
        private readonly static string[] BattlePhrases = new string[]
        {
            "For every action there is an equal and opposite reaction",
            "Gentlemen, you can't fight in here! This is the War Room",
            "Get ready to rumble",
            "He who fights and runs away, may live to fight another day",
            "Ready and waiting",
            "Serious as a heart attack",
            "What did you do in the war Daddy?",
            "You are in a Beauty Contest Every Day of your Life",
            "All's fair in love and war",
            "Amped up",
            "Attack is the best form of defence",
            "Battle stations",
            "Cry havoc and let slip the dogs of war",
            "Fight back the tears",
            "Fight the good fight",
            "Fight tooth and nail"
        };

        public static string GetRandomBattleString()
        {
            var random = new Random();

            return BattlePhrases[random.Next(BattlePhrases.Length)];
        }
    }
}

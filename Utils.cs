using HaroldTheBot.Raids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot
{
    public static class Utils
    {
        private static readonly Dictionary<char, double> charWidths = new()
        {
            {' ', 4 },
            {'A', 11 },
            {'B', 9},
            {'C', 10},
            {'D', 11},
            {'E', 8},
            {'F', 8},
            {'G', 11},
            {'H', 11},
            {'I', 4},
            {'J', 6},
            {'K', 10},
            {'L', 7},
            {'M', 15},
            {'N', 11},
            {'O', 12},
            {'P', 9},
            {'Q', 12},
            {'R', 9},
            {'S', 9},
            {'T', 9},
            {'U', 11},
            {'V', 11},
            {'W', 16},
            {'X', 10},
            {'Y', 10},
            {'Z', 10},
            {'Æ', 14},
            {'Ø', 12},
            {'Å', 12},
            {'a', 8},
            {'b', 8},
            {'c', 8},
            {'d', 8},
            {'e', 8},
            {'f', 8},
            {'g', 8},
            {'h', 8},
            {'i', 4},
            {'j', 4},
            {'k', 8},
            {'l', 4},
            {'m', 13},
            {'n', 8},
            {'o', 8},
            {'p', 8},
            {'q', 8},
            {'r', 6},
            {'s', 8},
            {'t', 5},
            {'u', 8},
            {'v', 8},
            {'w', 12},
            {'x', 8},
            {'y', 8},
            {'z', 8},
            {'æ', 13},
            {'ø', 8},
            {'å', 8},
            {'0', 9 },
            {'1', 6 },
            {'2', 9 },
            {'3', 8 },
            {'4', 9 },
            {'5', 9 },
            {'6', 9 },
            {'7', 9 },
            {'8', 9 },
            {'9', 9 },
            {'/', 9 },
            {'(', 7 },
            {')', 7 },
        };

        public static int CountSpaces(string str)
        {
            double numSpaces = 0;
            double spaceWidth = charWidths[' '];
            for (int i = 0; i < str.Length; i++)
            {
                if (charWidths.ContainsKey(str[i]))
                    numSpaces += charWidths[str[i]] / spaceWidth;
                else
                    numSpaces += 8 / spaceWidth;
            }

            return (int)Math.Floor(numSpaces);
        }


        public static int IndexOf(string[] array, string find)
        {
            for(int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(find))
                    return i;
            }

            return -1;
        }

        public static bool HasNextParameter(string[] array, int index)
        {
            return !(index + 1 >= array.Length || string.IsNullOrEmpty(array[index + 1]) || IsParameter(array[index + 1]));
        }

        public static bool IsParameter(string str)
        {
            return str[0] == '-';
        }

        

        public static bool IsTank(Job job)
        {
            return job == Job.WAR || job == Job.PLD || job == Job.DRK || job == Job.GNB || job == Job.MRD || job == Job.GLA;
        }

        public static bool IsHealer(Job job)
        {
            return job == Job.CNJ || job == Job.WHM || job == Job.SCH || job == Job.AST || job == Job.SGE;
        }

        public static bool IsMeleeDPS(Job job)
        {
            return job == Job.LNC || job == Job.PGL || job == Job.ROG || job == Job.DRG || job == Job.MNK || job == Job.NIN || job == Job.SAM || job == Job.RPR;
        }

        public static bool IsRangedDPS(Job job)
        {
            return job == Job.ARC || job == Job.BRD || job == Job.MCH || job == Job.DNC;
        }

        public static bool IsMagicDPS(Job job)
        {
            return job == Job.ACN || job == Job.THM || job == Job.BLM || job == Job.SMN || job == Job.RDM || job == Job.BLU;
        }

        public static string GenerateRandomAlphanumericString(int maxLength = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅabcdefghijklmnopqrstuvwxyzæøå0123456789";

            var random = new Random();
            var length = random.Next(maxLength-1) + 1;
            var randomString = new string(Enumerable.Repeat(chars, length)
                                                    .Select(s => s[random.Next(s.Length)]).ToArray());
            return randomString;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Raids
{
    public enum Job
    {
        ARC = 1, // Archer
        GLA = 2, // Gladiator
        LNC = 3, // Lancer
        MRD = 4, // Marauder
        PGL = 5, // Pugilist
        ACN = 6, // Arcanist
        CNJ = 7, // Conjurer
        THM = 8, // Thaumaturge
        ROG = 9, // Rogue
        BRD = 10, // Bard
        DRG = 11, // Dragoon
        MNK = 12, // Monk
        PLD = 13, // Paladin
        WAR = 14, // Warrior
        BLM = 15, // Black
        WHM = 16, // White Mage
        SCH = 17, // Scholar
        SMN = 18, // Summoner
        NIN = 19, // Ninja Icon
        AST = 20, // Astrologian
        DRK = 21, // Dark Knight
        MCH = 22, // Machinist
        RDM = 23, // Red Mage
        SAM = 24, // Samurai
        BLU = 25, // Blue Mage
        GNB = 26, // Gunbreaker
        DNC = 27, // Dancer
        RPR = 28, // Reaper
        SGE = 29, // Sage
    }

    public class RaidParticipant
    {
        public string Username { get; set; }
        public Job Role { get; set; }
    }
}

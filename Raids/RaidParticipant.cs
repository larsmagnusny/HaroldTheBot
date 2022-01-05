using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Raids
{
    public enum Job
    {
        ARC, // Archer
        GLA, // Gladiator
        LNC, // Lancer
        MRD, // Marauder
        PGL, // Pugilist
        ACN, // Arcanist
        CNJ, // Conjurer
        THM, // Thaumaturge
        ROG, // Rogue
        BRD, // Bard
        DRG, // Dragoon
        MNK, // Monk
        PLD, // Paladin
        WAR, // Warrior
        BLM, // Black
        WHM, // White Mage
        SCH, // Scholar
        SMN, // Summoner
        NIN, // Ninja Icon
        AST, // Astrologian
        DRK, // Dark Knight
        MCH, // Machinist
        RDM, // Red Mage
        SAM, // Samurai
        BLU, // Blue Mage
        GNB, // Gunbreaker
        DNC, // Dancer
        RPR, // Reaper
        SGE, // Sage
    }

    public class RaidParticipant
    {
        public string Username { get; set; }
        public Job Role { get; set; }
    }
}

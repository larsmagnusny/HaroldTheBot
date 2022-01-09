using HaroldTheBot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace HaroldTheBot.Data
{
    public class DataSeed : IDataSeed
    {
        private readonly HaroldDbContext _db;

        public DataSeed(HaroldDbContext db)
        {
            _db = db;
        }

        public void SeedData()
        {
            _db.Database.Migrate();

            if (!_db.Jobs.Any())
            {
                _db.Jobs.AddRange(new Job[]
                {
                    new Job { Id = 1, Name = "ARC" },// Archer
                    new Job { Id = 2, Name = "GLA" },// Gladiator
                    new Job { Id = 3, Name = "LNC" },// Lancer
                    new Job { Id = 4, Name = "MRD" },// Marauder
                    new Job { Id = 5, Name = "PGL" },// Pugilist
                    new Job { Id = 6, Name = "ACN" },// Arcanist
                    new Job { Id = 7, Name = "CNJ" },// Conjurer
                    new Job { Id = 8, Name = "THM" },// Thaumaturge
                    new Job { Id = 9, Name = "ROG" },// Rogue
                    new Job { Id = 10, Name = "BRD" },// Bard
                    new Job { Id = 11, Name = "DRG" },// Dragoon
                    new Job { Id = 12, Name = "MNK" },// Monk
                    new Job { Id = 13, Name = "PLD" },// Paladin
                    new Job { Id = 14, Name = "WAR" },// Warrior
                    new Job { Id = 15, Name = "BLM" },// Black
                    new Job { Id = 16, Name = "WHM" },// White Mage
                    new Job { Id = 17, Name = "SCH" },// Scholar
                    new Job { Id = 18, Name = "SMN" },// Summoner
                    new Job { Id = 19, Name = "NIN" },// Ninja Icon
                    new Job { Id = 20, Name = "AST" },// Astrologian
                    new Job { Id = 21, Name = "DRK" },// Dark Knight
                    new Job { Id = 22, Name = "MCH" },// Machinist
                    new Job { Id = 23, Name = "RDM" },// Red Mage
                    new Job { Id = 24, Name = "SAM" },// Samurai
                    new Job { Id = 25, Name = "BLU" },// Blue Mage
                    new Job { Id = 26, Name = "GNB" },// Gunbreaker
                    new Job { Id = 27, Name = "DNC" },// Dancer
                    new Job { Id = 28, Name = "RPR" },// Reaper
                    new Job { Id = 29, Name = "SGE" } // Sage
                });
                _db.SaveChanges();
            }
        }
    }
}

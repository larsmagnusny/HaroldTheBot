using HaroldTheBot.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (!_db.Jobs.Any())
            {
                _db.Jobs.AddRange(new Job[]
                {

                });
            }
        }
    }
}

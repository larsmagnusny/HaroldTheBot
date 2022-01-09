using HaroldTheBot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaroldTheBot.Data
{
    public class HaroldDbContext : DbContext
    {
        public DbSet<RaidEvent> RaidEvents { get; set; }
        public DbSet<RaidParticipant> RaidParticipants { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=HaroldRaidDb.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RaidEvent>().ToTable("RaidEvents");
            modelBuilder.Entity<RaidParticipant>().ToTable("RaidParticipants");
        }
    }
}

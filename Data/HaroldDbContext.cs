using HaroldTheBot.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
            string path = "/var/lib/haroldthebot/data";
            if (OperatingSystem.IsWindows())
            {
                path = "C:\\HaroldTheBot\\Data";
            }

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            optionsBuilder.UseSqlite($"Data Source={Path.Combine(path, "/HaroldRaidDb.db")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .ToTable("Jobs")
                .HasKey(o => o.Id);
            modelBuilder.Entity<RaidEvent>()
                .ToTable("RaidEvents")
                .HasKey(o => o.Id);
            modelBuilder.Entity<RaidParticipant>()
                .ToTable("RaidParticipants")
                .HasKey(o => new { o.RaidEventId, o.UserId });
        }
    }
}

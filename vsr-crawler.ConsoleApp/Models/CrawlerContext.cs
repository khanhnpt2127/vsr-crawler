using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vsr_crawler.ConsoleApp.Models 
{
    public class CrawlerContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");

        public DbSet<Crawler> Crawler { get; set; }

        public DbSet<CrawlerData> CrawlerData { get; set; }

        public DbSet<Professorship> Professorships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.FacultyMembers)
                .WithOne(e => e.Faculty);


            modelBuilder.Entity<Crawler>().HasOne(f => f.Professorship).WithMany(e => e.Crawlers);
            modelBuilder.Entity<CrawlerData>();
        }
    }
}




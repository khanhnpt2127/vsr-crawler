using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vsr_crawler.ConsoleApp.Models 
{
    public class CrawlerContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Data Source=127.0.0.1,1433;Database=VsrCrawler;User Id=sa; Password=@1234a56");

        public DbSet<Crawler> Crawler { get; set; }

        public DbSet<CrawlerData> CrawlerData { get; set; }

        public DbSet<Professorship> Professorships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Professorship>()
                    .HasMany(f => f.Crawlers)
                    .WithOne(e => e.Professorship);

            modelBuilder.Entity<CrawlerData>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}




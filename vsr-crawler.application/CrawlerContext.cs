using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using vsr_crawler.models;
using vsr_crawler.models.Expertise;

namespace vsr_crawler.Expertise.ConsoleApp
{
    public class CrawlerContext : DbContext
    {
        public DbSet<Category> Categories{ get; set; }
        public DbSet<models.Expertise.Expertise> Expertises { get; set; }
        public DbSet<Field> Fields { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    @"Data Source=LAPTOP-9JMM7RR2;Database=vsrCrawler;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", m =>m.MigrationsAssembly("vsr-crawler.models"));
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<models.Expertise.Expertise>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Field>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}

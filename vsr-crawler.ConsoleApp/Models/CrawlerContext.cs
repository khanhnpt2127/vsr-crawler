using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vsr_crawler.ConsoleApp.Models 
{
    public class CrawlerContext : DbContext
    { 
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");


        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Faculty>()
                .HasMany(f => f.FacultyMembers)
                .WithOne(e => e.Faculty);


            modelBuilder.Entity<Crawler>();
        }
    }
}




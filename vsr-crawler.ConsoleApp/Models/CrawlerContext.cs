using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vsr_crawler.ConsoleApp.Models 
{
    public class CrawlerContext : DbContext
    { 
        public DbSet<TestClass> TestClasses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=blogging.db");
    }

    public class TestClass 
    {
        public int TestClassId { get; set; }
        public string Name { get; set; }
    }


}




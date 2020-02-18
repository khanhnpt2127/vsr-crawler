using System.Collections.Generic;

namespace vsr_crawler.ConsoleApp.Models 
{
    public class Professorship 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Crawler> Crawlers { get; set; }
    }
}



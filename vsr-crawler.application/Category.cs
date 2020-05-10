using System.Collections.Generic;

namespace vsr_crawler.models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Expertise.Expertise> Expertises { get; set; }
    }
}

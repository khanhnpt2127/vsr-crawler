using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vsr_crawler.ConsoleApp.Models 
{
    public class Faculty
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Link { get; set; }

        public ICollection<FacultyMember> FacultyMembers { get; set; }
    }
}



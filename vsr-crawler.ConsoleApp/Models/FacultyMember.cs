using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vsr_crawler.ConsoleApp.Models 
{
    public class FacultyMember 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Telefon { get; set; }

        public string Fax { get; set; }

        public string Raum { get; set; }

        public string Email { get; set; }

        public string OfficeHour { get; set; }


        public Faculty Faculty{ get; set; }
        
    }
}



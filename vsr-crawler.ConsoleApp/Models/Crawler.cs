
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vsr_crawler.ConsoleApp.Models 
{
    public class Crawler 
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public string MainDivPath { get; set; }

        public string ImgPath { get; set; }

        public string NamePath { get; set; }
        public string RoomPath { get; set; }
        public int Type { get; set; }

    }
}



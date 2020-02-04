using System;
using HtmlAgilityPack; 
namespace vsr_crawler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();  
            HtmlDocument document = web.Load("http://www.tu-chemnitz.de/informatik/HomePages/Medieninformatik/team.php.en"); 
        
			var nodes = document.DocumentNode.SelectNodes("//main");
            foreach(var node in nodes) {
                Console.WriteLine(node);
            }

            Console.ReadLine();
        }
    }
}

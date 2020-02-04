using System;
using HtmlAgilityPack; 
namespace vsr_crawler.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("App is running ... ");

            try
            {
                HtmlWeb web = new HtmlWeb();  
                HtmlDocument document = web.Load("http://www.tu-chemnitz.de/informatik/HomePages/Medieninformatik/team.php.en"); 
            
                var nodes = document.DocumentNode.SelectNodes("//main//div[@class='mitarbeiter']");


                foreach(HtmlNode node in nodes) {
                    var imgs = node.SelectNodes(".//img");
                    

                    if(imgs != null) {
                        foreach(var img in imgs) {
                            Console.WriteLine(img.Attributes["src"].Value);
                        }
                    }
                }
                /*
                foreach(HtmlNode node in nodes) 
                {
                   var vcard = node.SelectNodes(".//address"); 
                   if(vcard != null) {
                   foreach(HtmlNode member in vcard) {
                       Console.WriteLine(member.SelectSingleNode("//img").Attributes["src"].Value);
                   } }
                }
                */

                Console.ReadLine();
            }
            catch(Exception ex) {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.WriteLine("Press any key to exit ...");
                Console.ReadLine();
            }
        }
    }
}

using System;
using HtmlAgilityPack; 
namespace vsr_crawler.ConsoleApp
{
    class Program
    {

        static string GetChildValueByInnerHtmlWithSpecialContains(HtmlNode htmlSources) {
            string res = "";

            if(!string.IsNullOrWhiteSpace(htmlSources.InnerHtml))
            if(htmlSources.InnerHtml.Contains("Room")) {
                System.Console.WriteLine((htmlSources.InnerHtml));
                res = htmlSources.InnerHtml;
            }
            return res;
        }


        static string GetChildValueByAttribute(HtmlNode htmlSources) {
            System.Console.WriteLine(htmlSources.Attributes["src"].Value);
            return htmlSources.Attributes["src"].Value;
        }

        static string GetChildValueByInnerHtml(HtmlNode htmlSources) {
            string res = "";

            if(!string.IsNullOrWhiteSpace(htmlSources.InnerHtml)) {
                System.Console.WriteLine((htmlSources.InnerHtml));
                res = htmlSources.InnerHtml;
            }
            
            return res;
        }

        static void Main(string[] args)
        {

            System.Console.WriteLine("App is running ... ");

            try
            {
                HtmlWeb web = new HtmlWeb();  
                HtmlDocument document = web.Load("http://www.tu-chemnitz.de/informatik/HomePages/Medieninformatik/team.php.en"); 
            
                var nodes = document.DocumentNode.SelectNodes("//main//div[@class='mitarbeiter']");

                foreach(HtmlNode node in nodes) {

                    //info: get Room

                    var selectedMainRoomNodes = node.SelectNodes(".//p");
                    //System.Console.WriteLine(h3[h3.Count-1].InnerHtml);
                    
                    if(selectedMainRoomNodes != null)
                    foreach(var selectedNode in selectedMainRoomNodes) {
                        GetChildValueByInnerHtmlWithSpecialContains(selectedNode);
                    }

                    // info: get Img
                    var selectedMainImgNodes = node.SelectNodes(".//img");

                    if(selectedMainImgNodes != null)
                    foreach(var selectedNode in selectedMainImgNodes) {
                        GetChildValueByAttribute(selectedNode);
                    }

                    // info: get Name

                    var selectedMainNameNodes = node.SelectNodes(".//h3");

                    if(selectedMainNameNodes != null)
                        foreach(var selectedNode in selectedMainNameNodes) 
                            GetChildValueByInnerHtml(selectedNode);
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

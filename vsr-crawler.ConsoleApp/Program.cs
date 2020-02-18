using System;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using vsr_crawler.ConsoleApp.Models;
using System.Linq;
using System.Net;
using System.IO;
using System.Collections.Generic;

namespace vsr_crawler.ConsoleApp
{
    class Program
    {
        static string GetChildValueByInnerHtmlWithSpecialContains(HtmlNode htmlSources, int type = 0)
        {
            string res = "";

            if (!string.IsNullOrWhiteSpace(htmlSources.InnerHtml))
                if (htmlSources.InnerHtml.Contains("Raum") || htmlSources.InnerHtml.Contains("Zimmer") && type == 0)
                {
                    res = htmlSources.InnerHtml;
                }
                else if (type != 0)
                {
                    //Console.WriteLine(htmlSources.ChildNodes[2].InnerHtml);
                    res = Regex.Replace(htmlSources.ChildNodes[2].InnerHtml, @"\s+", "");
                }

            System.Console.WriteLine(res);
            return res;
        }


        static string GetChildValueByAttribute(HtmlNode htmlSources)
        {
            System.Console.WriteLine(htmlSources.Attributes["src"].Value);

            return htmlSources.Attributes["src"].Value;
        }

        static string GetChildValueByInnerHtml(HtmlNode htmlSources, int type = 0)
        {
            string res = "";

            if (!string.IsNullOrWhiteSpace(htmlSources.InnerHtml))
            {
                if (htmlSources.HasChildNodes && type == 0)
                    res = htmlSources.LastChild.InnerHtml;
                else
                    res = Regex.Replace(htmlSources.ChildNodes[0].InnerHtml, @"\s+", "");
            }

            System.Console.WriteLine(res);
            return res;
        }



        static bool DownloadImageFromURL(string url, string destinationPath, string nameOfImage)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    //Special Case: with https infomatik
                    if(!url.Contains("osg.informatik.tu-chemnitz.de"))
                        client.DownloadFile(new Uri(url), destinationPath + nameOfImage);
                    else {
                        var url_fixed = new Uri(url);


                        string url_fixed_string = "https://" + url_fixed.Host + url_fixed.PathAndQuery; 
                        client.DownloadFile(new Uri(url_fixed_string), destinationPath + nameOfImage);
                    }
                }

                return true;
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        static void Main(string[] args)
        {

            System.Console.WriteLine("App is running ... ");

            List<Crawler> listOfCrawler;
            using (var context = new CrawlerContext())
            {
                listOfCrawler = context.Crawler.ToList();
            }

            foreach (var crawler in listOfCrawler)
            {
                try
                {
                    string uri = crawler.Url;
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument document = web.Load(uri);

                    var nodes = document.DocumentNode.SelectNodes(crawler.MainDivPath);

                    List<string> listOfRoom = new List<string>();
                    List<string> listOfImage = new List<string>();
                    List<string> listOfName = new List<string>();

                    foreach (HtmlNode node in nodes)
                    {

                        CrawlerData crawlerData = new CrawlerData();

                        //info: get Room

                        var selectedMainRoomNodes = node.SelectNodes(crawler.RoomPath);
                        //System.Console.WriteLine(h3[h3.Count-1].InnerHtml);

                        if (selectedMainRoomNodes != null)

                            foreach (var selectedNode in selectedMainRoomNodes)
                            {
                                listOfRoom.Add(GetChildValueByInnerHtmlWithSpecialContains(selectedNode, crawler.Type));
                            }


                        // info: get Img
                        var selectedMainImgNodes = node.SelectNodes(crawler.ImgPath);

                        if (selectedMainImgNodes != null)
                            foreach (var selectedNode in selectedMainImgNodes)
                            {
                                var imagePath = GetChildValueByAttribute(selectedNode);
                                imagePath = Regex.Replace(imagePath, @"\s+", String.Empty);
                                Uri rootUri = new Uri(uri);

                                string queryUri = "";
                                string lastItem = rootUri.Segments.Last();
                                foreach (var item in rootUri.Segments)
                                {
                                    if (!item.Equals(lastItem))
                                        queryUri += item;
                                }

                                String[] strlist = imagePath.Split("/",
                                            StringSplitOptions.RemoveEmptyEntries);

                                string NameOfFile = strlist.LastOrDefault();
                                System.Console.WriteLine(NameOfFile);
                                if (string.IsNullOrEmpty(NameOfFile))
                                {
                                    Random random = new Random();
                                    NameOfFile = "default_" + random.Next();
                                }
                                //TODO: getImage()
                                if (!imagePath.Contains("http"))
                                {
                                    imagePath = "http://" + rootUri.Host + queryUri + imagePath;
                                }
                                DownloadImageFromURL(imagePath, Environment.CurrentDirectory + "/images/", NameOfFile);
                                listOfImage.Add(NameOfFile);
                            }

                        // info: get Name

                        var selectedMainNameNodes = node.SelectNodes(crawler.NamePath);

                        if (selectedMainNameNodes != null)
                            foreach (var selectedNode in selectedMainNameNodes)
                            {
                                listOfName.Add(GetChildValueByInnerHtml(selectedNode, crawler.Type));
                            }

                    }


                    if (listOfImage.Count == listOfName.Count && listOfImage.Count == listOfRoom.Count)
                    {
                        List<CrawlerData> listOfCrawlerData = new List<CrawlerData>();
                        for (int i = 0; i < listOfName.Count; i++)
                        {
                            listOfCrawlerData.Add(new CrawlerData
                            {
                                Name = listOfName[i],
                                ImageName = listOfImage[i],
                                Room = listOfRoom[i]
                            });
                        }

                        using (var context = new CrawlerContext())
                        {
                            context.CrawlerData.AddRange(listOfCrawlerData);
                            context.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    Console.WriteLine("1st");
                }
            }
        }
    }
}

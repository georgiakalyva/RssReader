using System;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Collections.Generic;
using System.Linq;

namespace RssReader
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://azurecomcdn.azureedge.net/en-in/blog/topics/cognitive-services/feed/";
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();
            foreach (SyndicationItem item in feed.Items)
            {
                String subject = item.Title.Text;
                String summary = item.Summary.Text;
                String link = item.Links.FirstOrDefault().Uri.ToString();
                String date = item.PublishDate.ToString("dd/MM/yyyy");

                Console.WriteLine("*"+subject+"*");
                Console.WriteLine("    " + link);
                Console.WriteLine("    " + date);
                Console.WriteLine("    " + summary);
                Console.WriteLine();
            }

            Console.ReadLine();

        }
    }
}

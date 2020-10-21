using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using Mono.Web;

namespace EmailLinkFinder
{
    public class Link
    {
        public string FileName { get; set; }
        public string Address { get; set; }
    }

    public class EmailLinkFinder
    {
        public List<Link> GetLinks(string message)
        {
            List<Link> links = new List<Link>();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(message);
            HtmlNodeCollection rows = htmlDocument.DocumentNode.SelectNodes("//a[@href]");

            foreach (HtmlAgilityPack.HtmlNode row in rows)
            {
                foreach (var at in row.Attributes)
                {
                    if (at.Name == "href")
                    {
                        Link link = new Link();
                        link.Address = HttpUtility.HtmlDecode(at.Value);
                        link.FileName = at.OwnerNode.FirstChild.InnerHtml;
                        links.Add(link);
                    }
                }
            }

            return links;
        }

    }
}

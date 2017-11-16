using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HtmlAgilityPack;
using System.Collections;
using System.Text.RegularExpressions;

namespace BLService
{
    public class BLService : IBLService
    {
        ArrayList IBLService.GetPrices(HtmlDocument doc)
        {
            HtmlDocument html = new HtmlDocument();
            html.Load(@"D:\testing.html");

            HtmlNode checkmark = GetLineOfPVMKodas(html);
            if (checkmark == null)
                return null;

            ArrayList lines = new ArrayList();
            Tuple<string, string> newProduct;
            HtmlNode lineNode = checkmark.NextSibling.NextSibling;
            string product;
            if (Regex.Matches(lineNode.InnerText, @"[a-zA-Z]")
                .Count == 0)
                lineNode = lineNode.NextSibling.NextSibling;

            while (Regex.Matches(lineNode.InnerText, @"[a-zA-Z]")
                .Count != 0)
            {
                Match match = Regex.Match(lineNode.InnerText, @"\s(\d+).(\d+)");
                if (match.Success)
                {
                    product = lineNode.InnerText.Substring(0, match.Index);
                    newProduct = new Tuple<string, string>(product, match.Value);
                    if (!lines.Contains(newProduct))
                        lines.Add(newProduct);
                }
                lineNode = lineNode.NextSibling.NextSibling;
            }

            return lines;
        }

        HtmlNode GetLineOfPVMKodas(HtmlDocument doc)
        {

            if (doc == null)
            {
                return null;
            }

            try
            {
                List<HtmlNode> items = doc.DocumentNode
                    .SelectNodes("//*[text()='PVM']").ToList();

                foreach (HtmlNode node in items)
                {
                    HtmlNode nextWord = node.NextSibling.NextSibling.NextSibling.NextSibling;
                    if (nextWord.InnerText.Equals("kodas"))
                    {
                        return node.ParentNode;
                    }
                }
                return null;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("Nebuvo nuskaityta jokia preke! " + e);
                return null;
            }
        }
    }
}

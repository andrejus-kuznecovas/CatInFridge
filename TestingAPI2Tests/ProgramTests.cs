using Microsoft.VisualStudio.TestTools.UnitTesting;
using HtmlAgilityPack;
using TestingAPI2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TestingAPI2.Tests
{
    [TestClass()]
    public class ProgramTests
    {

        [TestMethod()]
        /*public void GettingLineOfPVMKodasTest()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(@"D:\testing2.html");

            HtmlNode line = Ocr.GetLineOfPVMKodas(doc);
            string whaaat = line.ToString();
            int Start = 0, End = 0;
            string strStart = "PVM";
            string strEnd = "kodas";
            string nuNaxj = "";
            if (whaaat.Contains(strStart) && whaaat.Contains(strEnd))
            {
                Start = whaaat.IndexOf(strStart, 0) + whaaat.Length;
                End = whaaat.IndexOf(strEnd, Start);
                nuNaxj = whaaat.Substring(Start, End - Start);
            }
            else
            {
                Assert.IsNull(line);
            }
            var noOfWords = Regex.Split(nuNaxj.Substring(0, nuNaxj.Length - 1), " ")
                .Length;

            //int count = nuNaxj.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Count();
            Assert.Equals(1, noOfWords);
        }*/

        [TestMethod()]
        public void GettingLineOfPVMKodasTest2()
        {
            Assert.IsNull(Ocr.GetLineOfPVMKodas(null));
        }
    }
}
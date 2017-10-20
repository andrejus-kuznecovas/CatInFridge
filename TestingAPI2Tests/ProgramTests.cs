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

        /*[TestMethod()]
        public void GettingLineOfPVMKodasTest2()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(@"D:\testing.html");

            HtmlNode htmlLine = Ocr.GetLineOfPVMKodas(doc);
            string line = htmlLine.ToString();
            int Start = 0, End = 0;
            string strStart = "PVM";
            string strEnd = "kodas";
            string wordsInBetween = "";
            if (line.Contains(strStart) && line.Contains(strEnd))
            {
                Start = line.IndexOf(strStart, 0) + line.Length;
                End = line.IndexOf(strEnd, Start);
                wordsInBetween = line.Substring(Start, End - Start);
            }
            else
            {
                Assert.IsNull(htmlLine);
            }
            var noOfWords = Regex.Split(wordsInBetween.Substring(0, wordsInBetween.Length - 1), " ")
                .Length;
            
            Assert.AreEqual(1, noOfWords);
        }*/

        [TestMethod()]
        public void GettingLineOfPVMKodasTestOfNullDocument()
        {
            Assert.IsNull(Ocr.GetLineOfPVMKodas(null));
        }
        
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void OcrHtmlTestOfReturnType()
        {
            //HtmlDocument doc = new HtmlDocument();
            //doc.Load(@"D:\testing.html");
            //Assert.AreEqual(doc.GetType(), Ocr.OcrHtml(@"D:\cekis.jpg").GetType());

            Assert.IsInstanceOfType(Ocr.OcrHtml(@"D:\cekis.jpg"), typeof(HtmlDocument));
        }

        [TestMethod()]
        public void GetPricesTestOfNullPic()
        {
            Assert.IsNull(Ocr.GetPrices(@"D:\TestNullPic.jpg"));
        }

        [TestMethod()]
        [ExpectedException(typeof(System.ArgumentNullException))]
        public void GettingLineOfPVMKodasTestOfExceptionThrowing()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(@"D:\TestZeroItemsHtml.html");

            Ocr.GetLineOfPVMKodas(doc);

            /*
            try
            {
                var obj = Ocr.GetLineOfPVMKodas(doc);
                Assert.Fail("An exception should have been thrown");
            }
            catch (ArgumentNullException e)
            {
                Assert.AreEqual("Prekiu nuskaityti nepavyko", e.Message);
            }*/
        }

        [TestMethod()]
        public void FixStringsTest()
        {
            Assert.AreEqual("ace", SearchEngine.FixStrings("ąČe"));
        }
    }
}
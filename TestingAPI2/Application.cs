using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestingWindowsForms;

namespace TestingAPI2
{
    class Start
    {
        [STAThread]
        static void Main(string[] args)
        {
            Repository.productPath = Path.GetFullPath(@"..\..\") + "Products.xml";
            Repository.shopPath = Path.GetFullPath(@"..\..\") + "Shops.xml";
            Application.Run(new Form1());
        }
    }
}

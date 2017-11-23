using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    class CustomDictComparer : Comparer<Dictionary<string, double>>
    {
        public override int Compare(Dictionary<string, double> dict1, Dictionary<string, double> dict2)
        {
            foreach (KeyValuePair<string, double> entry in dict2)
            {
                Console.WriteLine(entry);
            }
            return 1;
        }
    }
}
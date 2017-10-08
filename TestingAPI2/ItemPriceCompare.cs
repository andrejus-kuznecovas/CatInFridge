using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2
{
    public class ItemPriceCompare : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}

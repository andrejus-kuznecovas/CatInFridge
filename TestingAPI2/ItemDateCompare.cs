using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2
{
    public class ItemDateCompare : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.Date.CompareTo(y.Date);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2.Entities
{
    [Serializable]
    public class Product       //entity
    {
        public string name;
        public string price;
        public DateTime date;
        public Shop shop;

        public Product(string name, string price , Shop shop)
        {
            this.date = DateTime.Now;
            this.name = name;
            this.shop = shop;
            this.price = price;
        }

        public Product() { }

    }
}

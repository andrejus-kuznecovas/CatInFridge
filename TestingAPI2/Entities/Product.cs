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
        //Shop shop;
        public string shop;

        Product()
        { }
        public Product(string name, string price)
        {
            this.name = name;
            this.price = price;
            date = DateTime.Now;
        }
        public Product(string name, string price, string shop)
        {
            this.name = name;
            this.price = price;
            this.shop = shop;
            date = DateTime.Now;
        }

        public Product(string name, string price, string shop, string date)
        {
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", new CultureInfo("lt-LT")
                , DateTimeStyles.None, out this.date))
                this.date = DateTime.Now;

            this.name = name;
            this.shop = shop;
            this.price = price;
        }

    }
}

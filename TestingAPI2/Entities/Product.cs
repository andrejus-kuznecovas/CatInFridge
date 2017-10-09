using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2.Entities
{
    class Product       //entity
    {
        string name;
        double price;
        DateTime date;

        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
            this.date = DateTime.Now;
        }

        public Product(string name, double price, string date)
        {
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", new CultureInfo("lt-LT")
                , DateTimeStyles.None, out this.date))
                this.date = DateTime.Now;

            this.name = name;
            this.price = price;
        }

    }
}

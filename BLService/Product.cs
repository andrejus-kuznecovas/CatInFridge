using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    public enum Category
    {
        MEAT, VEGETABLES_FRUITS, DAIRY, DRINKS, ALCOHOL, BREAD, SWEETS, OTHER, UNRECOGNIZED

    }
    public enum Shop
    {
        MAXIMA, IKI, RIMI, NORFA, OTHER, UNRECOGNIZED

    }
    public class Product 
    {
        public string name;
        public string price;
        public DateTime date;
        public Category category;
        public Shop shop;

        public Product(string name, string price, string shop, string category)
        {
            this.date = DateTime.Now;
            this.name = name;
            Enum.TryParse(category, out Category cat);
            this.category = cat;
            this.price = price;
            Enum.TryParse(shop, out Shop sh);
            this.shop = sh;
        }

        public Product() {
        }

    }
}

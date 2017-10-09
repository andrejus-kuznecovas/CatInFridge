using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2
{
    public enum Category
    {
        MEAT, VEGETABLES_FRUITS, DAIRY, DRINKS, ALCOHOL, BREAD, SWEETS, OTHER, UNRECOGNIZED

    }
    class Item
    {
        public string productName;
        public double price;
        public Category category;

        public Item(string productName, double price) 
        {
            this.price = price;
            this.productName = productName;
        }

        public string GetProductName()
        {
            return this.productName;

        }

        public double getPrice()
        {
            return price;
        }


    }
}

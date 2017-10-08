using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingAPI2
{
 
    public class Item : IEquatable<Item>
    {
        public bool Saved
        { get; set; }
        public string Name
        { get; set; }

        public string Store
        { get; set; }

        public int Price
        { get; set; }

        public DateTime Date
        { get; set; }

        public Item(string name)
        {
            this.Name = name;
            this.Store = "MissingSt";
            this.Price = Int32.MaxValue;
            this.Date = DateTime.Now.Date;
        }

        public Item(string name, string store)
            : this(name)
        {
            this.Store = store;
        }

        public Item(string name, string store, int price)
            : this(name, store)
        {
            this.Price = price;
        }

        public Item(string name, int price)
            : this(name)
        {
            this.Price = price;
            this.Store = "MissingSt";

        }

        public Item(string name, int price, DateTime date)
            : this(name, price)
        {
            this.Date = date;
        }

        public Item(string name, int price, string date)
            : this(name, price)
        {
            this.Date = DateTime.Parse(date);
        }

        public Item(string name, string store, int price, DateTime date)
            : this(name, store, price)
        {
            this.Date = date;
        }

        public Item(string name, string store, int price, string date)
            : this(name, store, price)
        {
            this.Date = DateTime.Parse(date);
        }

        override public String ToString()
        {
            return (Name + " | " + Store + " | " + Price.ToString() + " | " + Date.ToString());
        }

        public bool Equals(Item other)
        {
            return (new ItemNameCompare().Compare(this, other) == 0
                && new ItemStoreCompare().Compare(this, other) == 0
                && new ItemPriceCompare().Compare(this, other) == 0
                && new ItemDateCompare().Compare(this, other) == 0);
        }

        public bool isComplete()
        {
            return (Store != "MissingSt" && Store != "") && (Price != 0);
        }
    }
}

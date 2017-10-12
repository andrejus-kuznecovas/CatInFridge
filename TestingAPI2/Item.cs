namespace TestingAPI2
{
    public enum Category
    {
        MEAT, VEGETABLES_FRUITS, DAIRY, DRINKS, ALCOHOL, BREAD, SWEETS, OTHER, UNRECOGNIZED

    }
    public enum Shop
    {
        MAXIMA, IKI, RIMI, NORFA, OTHER, UNRECOGNIZED

    }
    class Item
    {
        private string productName;
        private double price;
        private Category category;
        private Shop shop;

        /** If one (or both) of the enums are not passed in constructor, their are set to 'UNRECOGNIZED'*/

        /* Constructor #1: both enums are set to 'UNRECOGNIZED'*/
        public Item(string productName, double price)
        {
            this.Price = price;
            this.ProductName = productName;
            this.Category = Category.UNRECOGNIZED;
            this.Shop = Shop.UNRECOGNIZED;
        }


        /* Constructor #2: category is recognized, shop is unrecognized*/
        public Item(string productName, double price, string category)
        {
            this.Price = price;
            this.ProductName = productName;
            this.Category = Category.UNRECOGNIZED;
            this.Shop = Shop.UNRECOGNIZED;
        }

        public string ProductName { get => productName; set => productName = value; }
        public double Price { get => price; set => price = value; }
        public Category Category { get => category; set => category = value; }
        public Shop Shop { get => shop; set => shop = value; }

        /* overridding ToString method to check the class fields more easily*/
        public override string ToString()
        {
            return "Name: " + ProductName + ", price: " + Price + ", category: " + Category + ", shop: " + Shop + ".";
        }
    }
}

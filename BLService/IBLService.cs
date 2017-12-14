﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HtmlAgilityPack;
using System.Collections;

namespace BLService
{
    [ServiceContract]
    public interface IBLService
    {
        [OperationContract]
        List<Product> GetPrices(byte[] image);

        [OperationContract]
        List<Shop> GetShops();

        [OperationContract]
        void Post(List<Product> products, Shop shop);

        [OperationContract]
        string Test();

        [OperationContract]
        List<Product> Search(string itemName);

        [OperationContract]
        Stats GetStats(List<Product> prods);
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public double Price { get; set; }

        [DataMember(IsRequired = true)]
        public Cat Category { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Shop ProductShop { get; set; }

        /*
        public Product(string name, double price, string cat, DateTime date, string shop )
        {
            Name = name;
            Price = price;
            Enum.TryParse(cat, out Cat categ);
            Category = categ;
            Date = date;
            ProductShop.Name = shop;
        }*/
    }

    [DataContract]
    public enum Cat
    {
        [EnumMember]
        MEAT,
        [EnumMember]
        VEGETABLES_FRUITS,
        [EnumMember]
        DAIRY,
        [EnumMember]
        DRINKS,
        [EnumMember]
        ALCOHOL,
        [EnumMember]
        BREAD,
        [EnumMember]
        SWEETS,
        [EnumMember]
        OTHER,
        [EnumMember]
        UNRECOGNIZED
    }

    [DataContract]
    public class Shop
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name
        {
            get; set;
        }
    }
        [DataContract]
        public class Stats
        {
            //Contains money spent per purchase for each product category and category name
            [DataMember]
            public Dictionary<string, double> spendingsByCategory;

            //Contains money spent per purchase for each shop and shop name
            [DataMember]
            public Dictionary<string, double> spendingsByShop;

            //Contains the average price of a product for each category and category name
            [DataMember]
            public Dictionary<string, double> averageByCategory;

            //Contains the average price of a product for each shop and shop name
            [DataMember]
            public Dictionary<string, double> averageByShop;

            //Contains the most popular product for each cateogry and category name
            [DataMember]
            public Dictionary<string, string> mostPopularByCategory;

            //Contains the most popular product's name for each shop and shop name
            [DataMember]
            public Dictionary<string, string> mostPopularByShop;

            //Contains the cheapest item's name for each category
            [DataMember]
            public Dictionary<string, Product> cheapestByCategory;

            //Contains the category name the cheapest item's name for that category
            [DataMember]
            public Dictionary<string, Product> cheapestByShop;
        }
}

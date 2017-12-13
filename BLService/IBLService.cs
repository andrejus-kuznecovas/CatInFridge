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
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Price { get; set; }

        [DataMember]
        public Cat Category { get; set; }

        [DataMember]
        public DateTime Date { get; set }
    }

    [DataContract]
    public enum Cat
    {
        MEAT, VEGETABLES_FRUITS, DAIRY, DRINKS, ALCOHOL, BREAD, SWEETS, OTHER, UNRECOGNIZED
    }

    [DataContract]
    public class Shop
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

}

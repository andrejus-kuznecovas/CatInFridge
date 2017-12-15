using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HtmlAgilityPack;
using System.Collections;
using System.ComponentModel.DataAnnotations;

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
        int InsertProduct(Product p);

        [OperationContract]
        int UpdateProduct(Product p);

        [OperationContract]
        int InsertShop(Shop s);

        [OperationContract]
        int DeleteShop(Shop s);

        [OperationContract] 
        List<Product> GetSimilarProducts(Product p);
        
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public string ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Price { get; set; }

        [DataMember]
        public int Category { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        [Required]
        public int ShopId { get; set; }
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

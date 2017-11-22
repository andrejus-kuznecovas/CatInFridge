using System;
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
        List<Product> GetPrices(string imageLoc);
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Price { get; set; }
    }
}

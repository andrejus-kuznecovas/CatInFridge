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
    public interface IAPIService
    {
        [OperationContract]
        List<Product> GetPrices(string imageLoc);

        [OperationContract]
        string Test(string a);
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

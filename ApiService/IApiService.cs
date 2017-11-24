using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ApiService
{
    [ServiceContract]
    public interface IAPIService
    {
        [OperationContract]
        List<Product> GetPrices(byte[] image);

        [OperationContract]
        List<Shop> GetShops();
    }

    [DataContract]
    public class Product
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Price { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HtmlAgilityPack;
using System.Collections;
using Statistics;

namespace BLService
{
    [ServiceContract]
    public interface IBLService
    {
        [OperationContract]
        string GetPrices(string imageLoc);

        [OperationContract]
        List<Product> Search(string itemName, string category, ArrayList itemList);

        [OperationContract]
        Stats GetStats(string command, List<Product> lst );

        // TODO: Add your service operations here
    }
}

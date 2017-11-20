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
        string GetPrices(string imageLoc);

        // TODO: Add your service operations here
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using WcfServiceLibrary2.ServiceReference1;

namespace WcfServiceLibrary2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public ServiceReference1.Shop[] GetShops()
        {
            BLServiceClient client = new BLServiceClient();
            return client.GetShops();
        }

    }
}

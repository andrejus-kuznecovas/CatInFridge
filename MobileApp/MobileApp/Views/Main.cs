using MobileApp.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MobileApp
{
    public class Main : Page
    {
        String s;
        List<Shop> str;
        BLServiceClient wcf;

        public Main()
        {
            var binding = new BasicHttpBinding
            {
                Name = "BasicHttpBinding_IBLService",
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647
            };

            wcf = new BLServiceClient(binding, new EndpointAddress("http://172.24.3.27/BLService/BLService.svc"));
            //wcf.GetShopsCompleted += Wcf_GetShopsCompleted;

            wcf.GetStringCompleted += Wcf_GetStringCompleted;
        }
        

        private void Wcf_GetShopsCompleted(object sender, GetShopsCompletedEventArgs e)
        {
            object str = e.Result;
        }

        private void Wcf_GetStringCompleted(object sender, GetStringCompletedEventArgs e)
        {
            var s = e.Result;
        }

    }
}

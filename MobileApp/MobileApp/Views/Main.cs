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
        public BLServiceClient wcf;

        public Main()
        {

            wcf = new BLServiceClient();
            wcf.GetShopsCompleted += Wcf_GetShopsCompleted;
            wcf.GetStringCompleted += Wcf_GetStringCompleted;
            wcf.GetStringAsync();

            
        }
        

        private void Wcf_GetShopsCompleted(object sender, GetShopsCompletedEventArgs e)
        {
            object str = e.Result;
        }

        private void Wcf_GetStringCompleted(object sender, GetStringCompletedEventArgs e)
        {
            s = e.Result;
        }

    }
}

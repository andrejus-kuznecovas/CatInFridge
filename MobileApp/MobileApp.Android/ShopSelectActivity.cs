using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MobileApp.Droid
{
    [Activity(Label = "ShopSelectActivity")]
    public class ShopSelectActivity : Activity
    {
        List<string> listItems = new List<string>();
        ArrayAdapter<String> adapter;
        int clickCounter = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ShopSelect);

            ListView lv = (ListView)FindViewById(Resource.Id.listViewShop);
            adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, listItems);
            lv.Adapter = adapter;

            Button backBtn = (Button)FindViewById(Resource.Id.buttonBack);

            backBtn.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            adapter.Add("AAAAAA");
            adapter.Add("BBBBBB");
            adapter.Add("CCCCCC");
            adapter.Add("DDDDDD");

            lv.ItemClick += listView_ItemClick;
        }

        void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var item = adapter.GetItem(e.Position);
            Toast.MakeText(this, item + " Clicked!", ToastLength.Short).Show();
        }

    }
}
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
using MobileApp.BLService;

namespace MobileApp.Droid
{
    [Activity(Label = "ProductResultActivity")]
    public class ProductResultActivity : Activity
    {
        List<Product> listItems = new List<Product>();
        ProductAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.SelectList);

            ListView lv = (ListView)FindViewById(Resource.Id.listView);
            adapter = new ProductAdapter(this, Android.Resource.Layout.SimpleListItem1, listItems);
            lv.Adapter = adapter;

            Button backBtn = (Button)FindViewById(Resource.Id.buttonBack);
            Button nextBtn = (Button)FindViewById(Resource.Id.buttonNext);
            nextBtn.Visibility = ViewStates.Gone;

            backBtn.Click += (e, a) => { StartActivity(typeof(ProductSelectActivity)); };

            Main.wcf.PostCompleted += (s, e) =>
            {
                RunOnUiThread(() => {
                    adapter = new ProductAdapter(this, Android.Resource.Layout.SimpleListItem1, e.Result);
                    lv.Adapter = adapter;
                });
            };
        }        
    }

    public class ProductAdapter : ArrayAdapter<Product>
    {
        List<Product> products;
        Activity context;

        public ProductAdapter(Activity context, int textViewResourceId, List<Product> objects) 
            : base(context, textViewResourceId, objects) {
            products = objects;
            this.context = context;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            convertView = (convertView ?? context.LayoutInflater.Inflate(Resource.Layout.customListItem, parent, false));

            TextView nameText = (TextView)convertView.FindViewById(Resource.Id.textName);
            TextView priceText = (TextView)convertView.FindViewById(Resource.Id.textPrice);

            Product p = products.ElementAt(position);

            nameText.Text = p.Name;
            priceText.Text = p.Price;

            return convertView;            
        }
    }
}
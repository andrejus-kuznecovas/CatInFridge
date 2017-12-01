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
using Android.Util;
using MobileApp.ServiceReference1;

namespace MobileApp.Droid
{
    [Activity(Label = "EditActivity")]
    public class EditActivity : Activity
    {
        private Dictionary<int, int> ids;
        private LinearLayout rootLayout;
        float density;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditLayout);
            density = Application.Context.Resources.DisplayMetrics.Density;

            Button nextBtn = (Button)FindViewById(Resource.Id.buttonNext2);
            nextBtn.Click += delegate
            {
                List<Product> products = CollectProducts();
                Main.products = products;

                StartActivity(typeof(ShopSelectActivity));
            };

            SetProducts(new Dictionary<string, string>());
        }

        private List<Product> CollectProducts()
        {
            List<Product> products = new List<Product>();

            foreach(KeyValuePair<int, int> i in ids)
            {
                EditText etProduct = (EditText)FindViewById(i.Key);
                EditText etPrice = (EditText)FindViewById(i.Value);

                products.Add(new Product() { Name = etProduct.Text, Price = etPrice.Text });
            }

            return products;
        }

        public void SetProducts(Dictionary<string, string> products)
        {
            ids = new Dictionary<int, int>();
            rootLayout = (LinearLayout)FindViewById(Resource.Id.linearLayout1);

            AddProduct(new Tuple<string, string>("Vanduo Neptunas", "1.20"));
            AddProduct(new Tuple<string, string>("Plastikine tara", "0.10"));

        }

        private void AddProduct(Tuple<string, string> product)
        {
            LinearLayout ll = new LinearLayout(this)
            {
                Orientation = Orientation.Horizontal
            };
            LinearLayout.LayoutParams p = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            ll.LayoutParameters = p;

            EditText etProduct = new EditText(this)
            {
                LayoutParameters = new ViewGroup.LayoutParams((int)Math.Round((250 * density) + 0.5), ViewGroup.LayoutParams.MatchParent)
            };

            EditText etPrice = new EditText(this)
            {
                LayoutParameters = new ViewGroup.LayoutParams((int)Math.Round((150 * density) + 0.5), ViewGroup.LayoutParams.MatchParent)
            };

            int id = View.GenerateViewId();
            etProduct.Id = id;
            int id2 = View.GenerateViewId();
            etPrice.Id = id2;
            ids.Add(id, id2);

            etProduct.Text = product.Item1;
            etPrice.Text = product.Item2;

            ll.AddView(etProduct);
            ll.AddView(etPrice);

            rootLayout.AddView(ll);
        }
    }
}
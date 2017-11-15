using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading;
using Android.Provider;
using System.Collections.Generic;
using Android.Content.PM;
using Java.IO;
using Android.Graphics;
using Android.Net;

namespace LoginSystem
{

    [Activity(Label = "LoginSystem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);
            Button loginBtn = FindViewById<Button>(Resource.Id.btnLogin);
            loginBtn.Click += Login_Click;


        }

        private void Login_Click(object sender, System.EventArgs e)
        {

            Intent i = new Intent(this, typeof(MainScreen));
            StartActivity(i);
        }
    }
}


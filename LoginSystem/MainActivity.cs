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

        ProgressBar circle;
        private string pass;
        static public string name;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);
            Button loginBtn = FindViewById<Button>(Resource.Id.btnLogin);
            circle = FindViewById<ProgressBar>(Resource.Id.progressBar1);
            loginBtn.Click += Login_Click;


        }

        private void Login_Click(object sender, System.EventArgs e)
        {
            //displays a loading progress circle
            circle.Visibility = Android.Views.ViewStates.Visible;
            Thread thread = new Thread(actRequest);
            thread.Start();

            //saves username and password ( later to use as an access to API)
            pass = e.Password;
            name = e.UserName;


            //Starts new activity (Main Screen)
            Intent i = new Intent(this, typeof(MainScreen));
            StartActivity(i);
        }

        private void actRequest()
        {
            Thread.Sleep(3000);
            RunOnUiThread(() => { circle.Visibility = Android.Views.ViewStates.Invisible; });
        }
    }
}


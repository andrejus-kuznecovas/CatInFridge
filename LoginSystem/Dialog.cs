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
using System.Text.RegularExpressions;
using Android;

namespace LoginSystem
{
    public class OnSignUpEventArgs : EventArgs
    {
        private string username;
        private string email;
        private string password;


        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public OnSignUpEventArgs(string username, string password, string email) : base()
        {
            this.username = username;
            this.password = password;
            this.email = email;
        }
    }

    public class Dialog : DialogFragment
    {
        private EditText username;
        private EditText password;
        private EditText email;

        public EventHandler<OnSignUpEventArgs> signUpComplete;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.Login, container, false);

            username = view.FindViewById<EditText>(Resource.Id.txtUsername);
            password = view.FindViewById<EditText>(Resource.Id.txtPassword);
            //email = view.FindViewById<EditText>(Resource.Id.txtEmail);
            InputValidator validator = new InputValidator();

            Button loginBtn = view.FindViewById<Button>(Resource.Id.btnLogin);
            
            loginBtn.Click += Login_Click;

            return view;
        }

        private void Login_Click(object sender, EventArgs e)
        {
           
                signUpComplete.Invoke(this, new OnSignUpEventArgs(username.Text.First().ToString().ToUpper(),
                    password.Text, email.Text));
                this.Dismiss();
            
        
        }


        private bool isInputCorrect()
        {
            InputValidator validator = new InputValidator();
            bool validation = true;
            Android.Graphics.Color n = new Android.Graphics.Color(255, 0, 0);

            if (!validator.CheckName(username.Text))
            {
                username.SetText("".ToCharArray(), 0, 0);
                username.SetHintTextColor(n);
                validation = false;
            }

            if (!validator.CheckPassword(password.Text))
            {
                password.SetText("".ToCharArray(), 0, 0);
                password.SetHintTextColor(n);
                validation = false;
            }

            if (!validator.CheckEmail(email.Text))
            {
                email.SetText("".ToCharArray(), 0, 0);
                email.SetHintTextColor(n);
                validation = false;
            }


            return validation;
        }
    }
}
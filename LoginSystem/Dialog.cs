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

namespace Login
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

        public OnSignUpEventArgs(string name, string password, string email, string age, string height, /*string weight, */string gender) : base()
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
            email = view.FindViewById<EditText>(Resource.Id.txtEmail);
            InputValidator validator = new InputValidator();

            signUpBtn = view.FindViewById<Button>(Resource.Id.btnDialogEmail);
            signUpBtn.Click += SignUpBtn_Click;

            return view;
        }

        private void Login_Click(object sender, EventArgs e)
        {
           
                signUpComplete.Invoke(this, new OnSignUpEventArgs(username.Text.First().ToString().ToUpper(),
                    password.Text, email.Text));
                this.Dismiss();
            
        
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_anim;
        }

        static public double GetHeight()
        {
            return Convert.ToDouble(height);
        }
        public static int GetAge()
        {
            return Convert.ToInt32(age);
        }
        public static bool GetGender()
        {
            if (gender.SelectedItem.ToString() == "Vyras")
                return true;
            else return false;
        }

        private bool isInputCorrect()
        {
            Validator validator = new Validator();
            bool validation = true;
            Android.Graphics.Color n = new Android.Graphics.Color(255, 0, 0);

            if (!validator.CheckName(name.Text))
            {
                name.SetText("".ToCharArray(), 0, 0);
                name.SetHintTextColor(n);
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

            if (!validator.CheckHeight(height.Text))
            {
                height.SetText("".ToCharArray(), 0, 0);
                height.SetHintTextColor(n);
                validation = false;
            }

            if (!validator.CheckAge(age.Text))
            {
                age.SetText("".ToCharArray(), 0, 0);
                age.SetHintTextColor(n);
                validation = false;
            }

            return validation;
        }
    }
}
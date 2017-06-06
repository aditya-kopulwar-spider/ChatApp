using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using com.sl.ChatApp;

namespace com.sl.chatapp
{
    [Activity(Label = "SL ChatApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class LogInActivity : Activity
    {
        EditText userNameEditText;
        Button loginButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            SetupUI();
        }

        private void SetupUI()
        {
            userNameEditText = (EditText)FindViewById(Resource.Id.username);
            loginButton = (Button)FindViewById(Resource.Id.login_button);
            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            String userName = (userNameEditText.Text).Trim();
            if (userName == null || userName == "")
            {
                Toast.MakeText(this, "Username can't be empty", ToastLength.Long).Show();
                return;
            }

            StartActivity(new Intent(this, typeof(ChatActivity)).PutExtra("Username", userName));
        }
    }
}
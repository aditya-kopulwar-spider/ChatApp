using Android.App;
using Android.Widget;
using Android.OS;

namespace ChatingApp
{
    [Activity(Label = "ChatingApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class ChatActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_chat);
        }
    }
}
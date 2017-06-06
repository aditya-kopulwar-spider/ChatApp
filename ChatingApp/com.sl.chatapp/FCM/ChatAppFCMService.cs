using Android.App;
using Firebase.Iid;
using Firebase.Messaging;

namespace com.sl.chatapp.FCM
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    class ChatAppFCMService : FirebaseInstanceIdService
    {
        public override void OnTokenRefresh()
        {
            if (FirebaseInstanceId.Instance.Token != null)
            {
                var refreshedToken = FirebaseInstanceId.Instance.Token;
                Android.Util.Log.Debug("TAG", "Refreshed token: " + refreshedToken);
                FirebaseMessaging fcm = FirebaseMessaging.Instance;
                fcm.SubscribeToTopic("Aditya");
            }
        }
    }
}
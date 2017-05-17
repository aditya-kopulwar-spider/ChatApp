using Android.App;
using Android.Widget;
using Android.OS;
using com.sl.ChatApp.adapters;
using com.sl.ChatApp;
using Firebase.Xamarin.Database;
using System.Collections.Generic;
using Firebase.Xamarin.Auth;
using Firebase.Xamarin.Database.Query;

namespace ChatingApp
{
    [Activity(Label = "ChatingApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class ChatActivity : Activity
    {
        FirebaseClient firebase;

        private ChatAdapter adapter;

        private EditText inputMessage;
        private Button sendButton;
        private ListView chatMessageListView;
        List<ChatMessage> messages = new List<ChatMessage>();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_chat);

            firebase = new FirebaseClient("https://chatapp-51f70.firebaseio.com/");

            initializeUI();
        }

        private void initializeUI()
        {
            inputMessage = FindViewById<EditText>(Resource.Id.input_text);
            sendButton = FindViewById<Button>(Resource.Id.send_button);
            chatMessageListView = FindViewById<ListView>(Resource.Id.message_list);

            sendButton.Click += delegate
            {
                UploadMessageToFCM();
            };
        }

        private async void UploadMessageToFCM()
        {

            var items = await firebase
                .Child("chats")
                .PostAsync(new ChatMessage(inputMessage.Text, "Test_User"));
            inputMessage.Text = "";

            DisplayChatMessage();
        }

        private async void DisplayChatMessage()
        {
            firebase = new FirebaseClient("https://chatapp-51f70.firebaseio.com/");

            var items = await firebase
                .Child("chats")
                .OrderByKey()
                .OnceAsync<ChatMessage>();

            foreach (var item in items)
            {
                messages.Add(item.Object);
            }

            if (messages.Count > 0)
            {
                adapter = new ChatAdapter(messages, this);
                adapter.NotifyDataSetChanged();
                chatMessageListView.Adapter = adapter;
            }
            
        }
    }
}
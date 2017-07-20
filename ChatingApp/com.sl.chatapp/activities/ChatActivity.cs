using Android.App;
using Android.Widget;
using Android.OS;
using com.sl.ChatApp.adapters;
using com.sl.ChatApp;
using Firebase.Xamarin.Database;
using System.Collections.Generic;
using System;
using Firebase.Database;

namespace com.sl.chatapp
{
    [Activity(Label = "ChatingApp")]
    public class ChatActivity : Activity, IChildEventListener
    {
        FirebaseClient firebase;

        private ChatAdapter adapter;

        private EditText inputMessage;
        private Button sendButton;
        private ListView chatMessageListView;
        List<ChatMessage> messages = new List<ChatMessage>();
        string userName;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.activity_chat);
            userName = Intent.GetStringExtra("Username");
            messages.Clear();

            firebase = new FirebaseClient("https://chatapp-51f70.firebaseio.com/");
            FirebaseDatabase.Instance.GetReference("chats").AddChildEventListener(this);

            InitializeUI();
            SetupAdapter();
        }

        private void SetupAdapter()
        {
            adapter = new ChatAdapter(messages, this, userName);
            chatMessageListView.Adapter = adapter;
        }

        private void InitializeUI()
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
            string currentTime = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            string messageText = inputMessage.Text;
            inputMessage.Text = "";
            var items = await firebase
                .Child("chats")
                .PostAsync(new ChatMessage(messageText, userName, currentTime));
        }

        public void OnChildAdded(DataSnapshot snapshot, string previousChildName)
        {
            ChatMessage message = new   ChatMessage()
            {
                Message = snapshot.Child("Message").Value.ToString(),
                Time = snapshot.Child("Time").Value.ToString(),
                User = snapshot.Child("User").Value.ToString()
            };

            messages.Add(message);

            adapter.NotifyDataSetChanged();
        }

        public void OnChildChanged(DataSnapshot snapshot, string previousChildName)
        {
            throw new NotImplementedException();
        }

        public void OnChildMoved(DataSnapshot snapshot, string previousChildName)
        {
            throw new NotImplementedException();
        }

        public void OnChildRemoved(DataSnapshot snapshot)
        {
            throw new NotImplementedException();
        }

        public void OnCancelled(DatabaseError error)
        {
            throw new NotImplementedException();
        }
    }
}
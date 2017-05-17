using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ChatingApp;
using Java.Lang;

namespace com.sl.ChatApp.adapters
{
    class ChatAdapter : BaseAdapter
    {
        private List<ChatMessage> messages;
        private Activity activity;

        public ChatAdapter(List<ChatMessage> messages, Activity activity)
        {
            this.messages = messages;
            this.activity = activity;
        }

        public override int Count => messages.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            LayoutInflater inflater = (LayoutInflater)activity.BaseContext.GetSystemService(Context.LayoutInflaterService);
            View messageView = inflater.Inflate(Resource.Layout.chat_row, null);

            TextView message_content, message_timeStamp;
            message_content = messageView.FindViewById<TextView>(Resource.Id.chatMessageText);
            message_timeStamp = messageView.FindViewById<TextView>(Resource.Id.chatMessageTimestamp);

            message_content.Text = messages[position].Message;
            message_timeStamp.Text = messages[position].Time;

            return messageView;
        }
    }
}
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using com.sl.chatapp;

namespace com.sl.ChatApp.adapters
{
    class ChatAdapter : BaseAdapter
    {
        private List<ChatMessage> messages;
        private Activity activity;
        private string userName;

        public ChatAdapter(List<ChatMessage> messages, Activity activity, string userName)
        {
            this.messages = messages;
            this.activity = activity;
            this.userName = userName;
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

            TextView message_content, message_timeStamp, message_user;
            if (userName.Equals(messages[position].User))
            {
                (messageView.FindViewById<RelativeLayout>(Resource.Id.othersMessageBox)).Visibility = ViewStates.Gone;
                message_content = messageView.FindViewById<TextView>(Resource.Id.selfChatMessageText);
                message_timeStamp = messageView.FindViewById<TextView>(Resource.Id.selfChatMessageTimestamp);
                message_user = messageView.FindViewById<TextView>(Resource.Id.selfChatMessageUserName);

                message_content.Text = messages[position].Message;
                message_timeStamp.Text = messages[position].Time;
                message_user.Text = messages[position].User;
            }
            else
            {
                (messageView.FindViewById<RelativeLayout>(Resource.Id.selfMessageBox)).Visibility = ViewStates.Gone;
                message_content = messageView.FindViewById<TextView>(Resource.Id.otherChatMessageText);
                message_timeStamp = messageView.FindViewById<TextView>(Resource.Id.otherChatMessageTimestamp);
                message_user = messageView.FindViewById<TextView>(Resource.Id.otherChatMessageUserName);

                message_content.Text = messages[position].Message;
                message_timeStamp.Text = messages[position].Time;
                message_user.Text = messages[position].User;
            }





            return messageView;
        }
    }
}
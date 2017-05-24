using System;

namespace com.sl.chatapp
{
    internal class ChatMessage
    {
        public string User { get; set; }

        public string Message { get; set; }

        public string Time { get; set; }

        public ChatMessage()
        {
        }

        public ChatMessage(string Message, string User, string DateTime)
        {
            this.User = User;
            this.Message = Message;
            Time = DateTime;
        }
    }
}
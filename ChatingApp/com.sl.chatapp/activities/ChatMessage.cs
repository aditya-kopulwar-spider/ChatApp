using System;

namespace ChatingApp
{
    internal class ChatMessage
    {
        public string User { get; set; }

        public string Message { get; set; }

        public string Time { get; set; }

        public ChatMessage()
        {
        }

        public ChatMessage(string Message, DateTime dateTime)
        {
            this.Message = Message;
            Time = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public ChatMessage(string Message, string User)
        {
            this.User = User;
            this.Message = Message;
        }
    }
}
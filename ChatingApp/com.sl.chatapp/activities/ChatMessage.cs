using System;

namespace ChatingApp
{
    internal class ChatMessage
    {
        private string v;

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
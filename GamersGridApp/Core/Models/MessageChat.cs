using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.Models
{
    public class MessageChat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<MessageChatUser> MessageChatUsers { get; set; }

        public ICollection<Message> ChatHistory { get; set; }

        //public MessageChat()
        //{
        //    ChatHistory = new List<Message>();
        //}
    }
}
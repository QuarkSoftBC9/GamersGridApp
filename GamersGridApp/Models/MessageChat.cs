using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class MessageChat
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }

        public ICollection<Message> ChatHistory { get; set; }

        //public MessageChat()
        //{
        //    ChatHistory = new List<Message>();
        //}
    }
}
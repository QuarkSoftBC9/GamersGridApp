using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class MessageChatUser
    {
        //[Key]
        //[Column(Order = 1)]
        public int MessageChatId { get; set; }
        //[Key]
        //[Column(Order = 2)]
        public int UserId { get; set; }
        public MessageChat Chat { get; set; }
        public User User { get; set; }
        public bool IsUpToDate { get; set; }

    }
}
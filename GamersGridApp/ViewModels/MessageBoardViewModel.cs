using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class MessageBoardViewModel
    {
        public ICollection<MessageChat> MessageChats { get; set; }

        public int CurrentChatID { get; set; }

        public string CurrentUserNickName { get; set; }
    }
}
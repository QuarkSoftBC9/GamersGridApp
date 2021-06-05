using GamersGrid.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Messageboard
{
    public class ChatGroupVM
    {
        public string CurrentUserNickName;
        public ChatGroup Group;
        public int CurrentMessageChatID;
    }
}

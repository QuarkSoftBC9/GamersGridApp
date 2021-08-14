using GamersGrid.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Messageboard
{
    public class MessageboardVM
    {
        public List<ChatGroup> ChatGroups { get; set; }

        public int? CurrentChatID { get; set; }

        public string CurrentUserNickName { get; set; }

        public MessageboardVM(){ ChatGroups = new List<ChatGroup>(); }
        public MessageboardVM(string currentUserNickname)
        {
            ChatGroups = new List<ChatGroup>();
            CurrentUserNickName = currentUserNickname;
        }
        public MessageboardVM(List<ChatGroup> chatGroups, int? currentChatId, string currentUserNickname) 
        {
            ChatGroups = chatGroups;
            CurrentChatID = currentChatId;
            CurrentUserNickName = currentUserNickname;
        }

    }
}

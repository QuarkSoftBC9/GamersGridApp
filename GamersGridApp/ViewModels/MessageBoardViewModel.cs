using GamersGridApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class MessageBoardViewModel
    {
        public List<MessageChat> MessageChats { get; set; }

        public int? CurrentChatID { get; set; }

        public string CurrentUserNickName { get; set; }
        protected MessageBoardViewModel()
        {

        }
        public MessageBoardViewModel(List<MessageChat> messageChats, int? currentChatId , string currentUserNickname)
        {
            foreach (var messageChat in messageChats)
            {
                if (messageChat.ChatHistory==null)
                {
                    messageChat.ChatHistory = new List<Message>();
                }
            }


                MessageChats = messageChats;
                CurrentChatID = currentChatId;
                CurrentUserNickName = currentUserNickname;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersGridApp.Persistence;
using Microsoft.AspNet.SignalR;
using System.Data.Entity;
using GamersGridApp.Core.Models;

namespace GamersGridApp
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void Connect(int chatId)
        {

            Groups.Add(Context.ConnectionId, chatId.ToString());

        }
        public void SendMessageToGroup(string userNickName, string message, int chatBoxID)
        {

            //Groups.Add(Context.ConnectionId, chatBoxID.ToString());
            var user = db.Users.Select(u=>u.UserAccount).Single(u => u.NickName == userNickName);
            var chatbox = db.MessageChats.Include(m => m.ChatHistory).Single(m => m.ID == chatBoxID);
            chatbox.ChatHistory.Add(new Message { MessageString = message, User = user, Time = DateTime.Now });
            db.SaveChanges();
            //Clients.All.getMessages(user.Email, message);
            Clients.Group(chatbox.ID.ToString()).getMessages(user.NickName, message, DateTime.Now);


        }
    }
}
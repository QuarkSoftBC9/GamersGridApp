using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Repositories
{
    public class MessageChatUserRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageChatUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMessageChatToDB(MessageChat messageChat)
        {
            _context.MessageChats.Add(messageChat);
        }

    }
}
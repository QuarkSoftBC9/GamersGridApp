using GamersGridApp.Core.Models;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GamersGridApp.Persistence.Repositories
{
    public class MessageChatRepository : IMessageChatRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageChatRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<MessageChat> GetMessageChats(int userid)
        {
            return _context.MessageChats
                .Where(mc => mc.MessageChatUsers.Select(mcu => mcu.UserId).Any(u => u.Equals(userid)))
                .Include(c => c.ChatHistory.Select(ch => ch.User))
                .Include(c=> c.MessageChatUsers.Select(mcu=>mcu.User))
                .ToList();
        }

        public MessageChat GetMessageChatOfTwoUsers(int currentUserid, int requestedUserId)
        {
            return _context.MessageChats.Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == currentUserid))
            .Where(m => m.MessageChatUsers.Any(mcu => mcu.UserId == requestedUserId))
            .Where(m => m.MessageChatUsers.Count == 2)
            .Include(c => c.ChatHistory.Select(ch => ch.User))
            .Include(c => c.MessageChatUsers).FirstOrDefault();
        }
        public MessageChat GetMessageChat(int chatId)
        {
            return _context.MessageChatUsers
                         .Where(mcu => mcu.MessageChatId == chatId)
                         .Include(mcu => mcu.Chat)
                         .Select(mcu => mcu.Chat)
                         .Include(c => c.ChatHistory.Select(ch => ch.User))
                         .FirstOrDefault();
        }

        public void AddMessageChatToDB(MessageChat messageChat)
        {
            _context.MessageChats.Add(messageChat);
        }

        public List<MessageChat> GetMessageChatsIncludedChatHistory(int userId)
        {
            return _context.MessageChatUsers.Where(mcu => mcu.UserId == userId).Select(mcu => mcu.Chat).Include(c => c.ChatHistory).ToList();
        }
    }
}
using GamersGridApp.Core.Models;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace GamersGridApp.Persistence.Repositories
{
    public class MessageChatUserRepository : IMessageChatUserRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageChatUserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddMessageChatUserToDB(MessageChatUser messageChatUser)
        {
            _context.MessageChatUsers.Add(messageChatUser);
        }

        public List<MessageChatUser> GetMessageChatRelationsForTwoUsers(int currentUserId, int requqestedUserId)
        {
            return _context.MessageChatUsers.Where(mcu => mcu.UserId == currentUserId || mcu.UserId == requqestedUserId).Include(mcu => mcu.Chat).ToList();
        }

       
    }
}
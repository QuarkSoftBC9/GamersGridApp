using GamersGridApp.Core.Models;
using System.Collections.Generic;

namespace GamersGridApp.Core.Repositories
{
    public interface IMessageChatUserRepository
    {
        void AddMessageChatUserToDB(MessageChatUser messageChatUser);
        List<MessageChatUser> GetMessageChatRelationsForTwoUsers(int currentUserId, int requqestedUserId);

    }
}
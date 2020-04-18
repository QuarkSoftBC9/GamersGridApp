using GamersGridApp.Core.Models;
using System.Collections.Generic;

namespace GamersGridApp.Core.Repositories
{
    public interface IMessageChatRepository
    {
        void AddMessageChatToDB(MessageChat messageChat);
        MessageChat GetMessageChat(int chatId);
        MessageChat GetMessageChatOfTwoUsers(int currentUserid, int requestedUserId);
        List<MessageChat> GetMessageChats(int userid);
        List<MessageChat> GetMessageChatsIncludedChatHistory(int userId);
    }
}
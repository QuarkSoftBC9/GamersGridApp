using GamersGridApp.Models;
using System.Collections.Generic;

namespace GamersGridApp.Repositories
{
    public interface IMessageChatRepository
    {
        void AddMessageChatToDB(MessageChat messageChat);
        MessageChat GetMessageChat(int chatId);
        MessageChat GetMessageChatOfTwoUsers(int currentUserid, int requestedUserId);
        List<MessageChat> GetMessageChats(int userid);
    }
}
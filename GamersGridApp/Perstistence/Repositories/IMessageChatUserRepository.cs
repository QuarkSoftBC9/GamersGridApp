using GamersGridApp.Models;

namespace GamersGridApp.Repositories
{
    public interface IMessageChatUserRepository
    {
        void AddMessageChatToDB(MessageChat messageChat);
    }
}

using GamersGridApp.Core.Repositories;

namespace GamersGridApp.Core
{
    public interface IUnitOfWork
    {
        IFollowsRepository Follows { get; set; }
        IGameRepository Games { get; set; }
        IGameAccountRepository GameAccounts { get; set; }
        IGameAccountStatsRepository GameAccountStats { get; set; }
        IMessageChatRepository MessageChats { get; set; }
        IMessageChatUserRepository MessageChatUsers { get; set; }
        INotificationsRepository Notifications { get; set; }
        IUserGameRepository UserGames { get; set; }
        IUserNotificationRepository UserNotifications { get; set; }
        IUserRepository GGUsers { get; set; }
        void Complete();
    }
}
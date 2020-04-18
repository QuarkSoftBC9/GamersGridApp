using GamersGridApp.Repositories;

namespace GamersGridApp.Perstistence
{
    public interface IUnitOfWork
    {
        IFollowsRepository Follows { get; }
        IGameAccountRepository GameAccounts { get; }
        IGameAccountStatsRepository GameAccountStats { get; }
        IGameRepository Games { get; }
        IMessageChatUserRepository MessageChatUsers { get; }
        IMessageChatRepository MessagesChat { get; }
        INotificationsRepository Notifications { get; }
        IUserGameRepository UserGames { get; }
        IUserNotificationRepository UserNotifications { get; }
        IUserRepository Users { get; }

        void Complete();
    }
}
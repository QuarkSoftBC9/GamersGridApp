using GamersGridApp.Models;
using GamersGridApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Perstistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGameRepository Games { get; private set; }
        public IUserGameRepository UserGames { get; private set; }
        public IUserRepository Users { get; private set; }
        public IFollowsRepository Follows { get; private set; }
        public IUserNotificationRepository UserNotifications { get; private set; }
        public IGameAccountRepository GameAccounts { get; private set; }
        public IGameAccountStatsRepository GameAccountStats { get; private set; }
        public IMessageChatRepository MessagesChat { get; private set; }
        public IMessageChatUserRepository MessageChatUsers { get; private set; }
        public INotificationsRepository Notifications { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Games = new GameRepository(context);
            UserGames = new UserGameRepository(context);
            Users = new UserRepository(context);
            Follows = new FollowsRepository(context);
            UserNotifications = new UserNotificationRepository(context);
            GameAccounts = new GameAccountRepository(context);
            GameAccountStats = new GameAccountStatsRepository(context);
            MessagesChat = new MessageChatRepository(context);
            MessageChatUsers = new MessageChatUserRepository(context);
            Notifications = new NotificationsRepository(context);
        }
        public void Complete()
        {

            _context.SaveChanges();
        }
    }
}
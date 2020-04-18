
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GamersGridApp.Core;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Perstistence.Repositories;

namespace GamersGridApp.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IFollowsRepository Follows { get; set; }
        public IGameRepository Games { get; set; }
        public IGameAccountRepository GameAccounts { get; set; }
        public IGameAccountStatsRepository GameAccountStats { get; set; }
        public IMessageChatRepository MessageChats { get; set; }
        public IMessageChatUserRepository MessageChatUsers { get; set; }
        public INotificationsRepository Notifications { get; set; }
        public IUserGameRepository UserGames { get; set; }
        public IUserNotificationRepository UserNotifications { get; set; }
        public IUserRepository GGUsers { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Follows = new FollowsRepository(context);

        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
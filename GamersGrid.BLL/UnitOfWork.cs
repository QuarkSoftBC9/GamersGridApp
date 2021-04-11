using GamersGrid.BLL.Interfaces;
using GamersGrid.BLL.Repositories;
using GamersGrid.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.BLL
{
    public class UnitOfWork : IUnitOfWork
    //: IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public FollowRelationsRepository FollowRelations { get; set; }
        public VideoGamesRepository Games { get; set; }
        public GameAccountRepository GameAccounts { get; set; }
        public GameAccountStatsRepository GameAccountStats { get; set; }
        //public IMessageChatRepository MessageChats { get; set; }
        //public IMessageChatUserRepository MessageChatUsers { get; set; }
        //public INotificationsRepository Notifications { get; set; }
        public UserGameRelationsRepository UsersGamesRelations { get; set; }
        //public IUserNotificationRepository UserNotifications { get; set; }
        public GGUserRepository GGUsers { get; set; }
        //public ITeamRepository Teams { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            FollowRelations = new FollowRelationsRepository(context);
            Games = new VideoGamesRepository(context);
            GameAccounts = new GameAccountRepository(context);
            GameAccountStats = new GameAccountStatsRepository(context);
            //MessageChats = new MessageChatRepository(context);
            //MessageChatUsers = new MessageChatUserRepository(context);
            //Notifications = new NotificationsRepository(context);
            UsersGamesRelations = new UserGameRelationsRepository(context);
            GGUsers = new GGUserRepository(context);
            //UserNotifications = new UserNotificationRepository(context);
            //Teams = new TeamRepository(context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

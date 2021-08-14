﻿using GamersGrid.BLL.Interfaces;
using GamersGrid.BLL.Repositories;
using GamersGrid.BLL.Repositories.Interfaces;
using GamersGrid.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.BLL
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext db { get; private set; }

        public IFollowRelationsRepository FollowRelations { get; }
        public IVideoGamesRepository Games { get; }
        public IGameAccountRepository GameAccounts { get; }
        public IGameAccountStatsRepository GameAccountStats { get; }
        //public IMessageChatRepository MessageChats { get; set; }
        //public IMessageChatUserRepository MessageChatUsers { get; set; }
        //public INotificationsRepository Notifications { get; set; }
        public IUserGameRelationsRepository UsersGamesRelations { get; }
        //public IUserNotificationRepository UserNotifications { get; set; }
        public IGGUserRepository GGUsers { get; }
        //public ITeamRepository Teams { get; set; }

        public UnitOfWork(ApplicationDbContext _db,
            IFollowRelationsRepository followsRepo,
            IVideoGamesRepository gamesRepo,
            IGameAccountRepository gameaccountsRepo,
            IGameAccountStatsRepository gameAccountStatsRepo,
            IUserGameRelationsRepository userGamesRelationRepo,
            IGGUserRepository usersRepo)
        {
            db = _db;
            FollowRelations = followsRepo;
            Games = gamesRepo;
            GameAccounts = gameaccountsRepo;
            GameAccountStats = gameAccountStatsRepo;
            //MessageChats = new MessageChatRepository(context);
            //MessageChatUsers = new MessageChatUserRepository(context);
            //Notifications = new NotificationsRepository(context);
            UsersGamesRelations = userGamesRelationRepo;
            GGUsers = usersRepo;
            //UserNotifications = new UserNotificationRepository(context);
            //Teams = new TeamRepository(context);
        }

        public async Task Save()
        {
            await db.SaveChangesAsync();
        }
    }
}

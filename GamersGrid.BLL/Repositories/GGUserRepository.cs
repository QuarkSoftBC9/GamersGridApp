using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.BLL.Repositories.Abstractions;
using GamersGrid.BLL.Repositories.Interfaces;
using GamersGrid.DAL;
using GamersGrid.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories
{
    public class GGUserRepository : Repository<GGuser>, IGGUserRepository
    {
        public GGUserRepository(ApplicationDbContext db) : base(db)
        {
        }

        public GGuser GetUser(string name)
        {
            return _db.Users
                .SingleOrDefault(u => u.NickName.Contains(name));
        }
        public List<GGuser> GetUsers()
        {
            return _db.Users.ToList();
        }

        public GGuser GetUser(int? userid)
        {
            return _db.Users
                .SingleOrDefault(u => u.Id == userid);
        }

        public List<GGuser> GetFollowersOfTwoUsersWithTheirFollowees(int userId1, int userId2)
        {
            return _db.FollowRelations
                    .Include(f => f.Follower)
                    .Include(f => f.User)
                    .Where(f => f.UserId == userId1 || f.UserId == userId2)
                    .Select(f => f.Follower)
                    .Distinct()
                    .Include(u => u.Followees)
                    .ToList();
        }

        public List<GGuser> SearchUsers(string searchstring)
        {
            return _db.Users
                 .Where(ggu => ggu.NickName.Contains(searchstring))
                 .ToList();
        }
        public List<GGuser> BetterSearchUsers(string searchstring)
        {
            return _db.Users
                .Where(u => u.LastName.Contains(searchstring) || u.FirstName.Contains(searchstring) || u.NickName.Contains(searchstring))
                .ToList();
        }

        //public GGuser GetUserContent(int appUserId)
        //{
        //    return _db.Users
        //        .Where(u => u.Id == appUserId)
        //        .Select(u => u.GameAccounts)
        //        .Include(ug => ug.UserGames.Select(g => g.GameAccount))
        //        .SingleOrDefault();
        //}

        public List<GGuser> GetOtherUsers(int loggeduserid)
        {
            return _db.Users
                .Where(u => u.Id != loggeduserid)
                .ToList();
        }

    }
}

using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GamersGridApp.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(string name)
        {
            return _context.GamersGridUsers
                .SingleOrDefault(u => u.NickName.Contains(name));
        }
        public User GetUser(int? userid)
        {
            return _context.GamersGridUsers
                .SingleOrDefault(u => u.ID == userid);
        }
        public User GetLoggedUser(string loggedUserId)
        {
            return _context.Users
                .Where(u => u.Id == loggedUserId).Select(u => u.UserAccount).SingleOrDefault();
        }

        public List<User> GetFollowersOfTwoUsersWithTheirFollowees(int userId1, int userId2)
        {
            return _context.Follows
                    .Include(f => f.Follower)
                    .Include(f => f.User)
                    .Where(f => f.UserId == userId1 || f.UserId == userId2)
                    .Select(f => f.Follower)
                    .Distinct()
                    .Include(u => u.Followees)
                    .ToList();
        }
        //public Follow FollowingRelation(int loggeduserid,int seconduserid)
        //{
        //    return _context.Follows
        //        .SingleOrDefault(f => f.FollowerId == loggeduserid && f.UserId == seconduserid);
        //}

        public List<User> SearchUsers(string searchstring)
        {
           return _context.GamersGridUsers
                .Where(ggu => ggu.NickName.Contains(searchstring))
                .ToList();
        }

        public User GetUserContent(string appUserId)
        {
            return _context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .Include(ug => ug.UserGames.Select(g => g.GameAccount))
                .SingleOrDefault();
        }
        
        public List<ApplicationUser> GetOtherUsers(string loggeduserid)
        {
            return _context.Users
                .Where(u => u.Id != loggeduserid)
                .ToList();
        }
        public int GetUserIdBasedOnAppID(string id)
        {
            return _context.Users
                .Where(u => u.Id == id)
                .Select(u => u.UserId)
                .Single();
        }
        
    }
}
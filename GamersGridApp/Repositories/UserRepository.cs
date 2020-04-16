using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public User GetLoggedUser(string loggedUserId)
        {
            return _context.Users
                .Where(u => u.Id == loggedUserId).Select(u => u.UserAccount).SingleOrDefault();
        }
        public int GetFollowsCount(int userid)
        {
            return _context.Follows
                .Count(f => f.UserId == userid);
        }
        public int GetFollowingsCount(int userid)
        {
            return _context.Follows
                .Count(f => f.FollowerId == userid);
        }
        public Follow FollowingRelation(int loggeduserid,int seconduserid)
        {
            return _context.Follows
                .SingleOrDefault(f => f.FollowerId == loggeduserid && f.UserId == seconduserid);
        }

        
    }
}
using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Repositories
{
    public class FollowsRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Follow GetFollowRelationOfTwoUsers(int currentUserId, int requestedUserId)
        {
            return _context.Follows.SingleOrDefault(f => f.FollowerId == currentUserId && f.UserId == requestedUserId);
        }

        public int GetFollowsCountForOneUser(int userId)
        {
            return _context.Follows.Count(f => f.UserId == userId);
        }
        public int GetFollowersCount(int userid)
        {
            return _context.Follows
                .Count(f => f.UserId == userid);
        }
        public int GetFollowingsCount(int userid)
        {
            return _context.Follows
                .Count(f => f.FollowerId == userid);
        }

    }
}
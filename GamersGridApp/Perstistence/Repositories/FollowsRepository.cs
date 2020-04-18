
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Persistence;
using GamersGridApp.Core.Models;

namespace GamersGridApp.Perstistence.Repositories
{
    public class FollowsRepository : IFollowsRepository
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
        public Follow GetFollowRelationOfTwoUsersIncludingUser(int currentUserId, int requestedUserId)
        {
            return _context.Follows
                .Include(f => f.User)
                .SingleOrDefault(f => f.User.ID == currentUserId && f.FollowerId == requestedUserId);
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

        public void Add(Follow follow)
        {
            _context.Follows.Add(follow);
        }
        public void Remove(Follow follow)
        {
            _context.Follows.Remove(follow);
        }

        public List<User> GetMessageUsersRelation(int userid)
        {
            return _context.GamersGridUsers
                .Where(g => g.Followers.Select(fo => fo.FollowerId)
                .Contains(userid) && g.Followees.Select(fo => fo.UserId)
                .Contains(userid)).ToList();

        }

        //public void Add(Follow follow)
        //{
        //    throw new NotImplementedException();
        //}

        //Follow IFollowsRepository.GetFollowRelationOfTwoUsers(int currentUserId, int requestedUserId)
        //{
        //    throw new NotImplementedException();
        //}

        //Follow IFollowsRepository.GetFollowRelationOfTwoUsersIncludingUser(int currentUserId, int requestedUserId)
        //{
        //    throw new NotImplementedException();
        //}

        //List<User> IFollowsRepository.GetMessageUsersRelation(int userid)
        //{
        //    throw new NotImplementedException();
        //}

        //public void Remove(Follow follow)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
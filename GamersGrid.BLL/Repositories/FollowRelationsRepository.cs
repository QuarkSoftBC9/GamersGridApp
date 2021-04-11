using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.BLL.Repositories.Abstractions;
using GamersGrid.BLL.Repositories.Interfaces;
using GamersGrid.DAL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories
{
    public class FollowRelationsRepository : Repository<FollowRelation>,IFollowRelationsRepository
    {
        public FollowRelationsRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<FollowRelation> GetFollowRelationOfTwoUsers(int currentUserId, int requestedUserId)
        {
            return await _db.FollowRelations.SingleOrDefaultAsync(f => f.FollowerId == currentUserId && f.UserId == requestedUserId);
        }
        public async Task<FollowRelation> GetFollowRelationOfTwoUsersIncludingUser(int currentUserId, int requestedUserId)
        {
            return await _db.FollowRelations
                .Include(f => f.User)
                .SingleOrDefaultAsync(f => f.User.Id == currentUserId && f.FollowerId == requestedUserId);
        }

        public async Task<int> GetFollowRelationsCountForOneUser(int userId)
        {
            return _db.FollowRelations.Count(f => f.UserId == userId);
        }
        public async Task<int> GetFollowersCount(int userid)
        {
            return await _db.FollowRelations
                .CountAsync(f => f.UserId == userid);
        }
        public async Task<int> GetFollowingsCount(int userid)
        {
            return await _db.FollowRelations
                .CountAsync(f => f.FollowerId == userid);
        }

        public void Add(FollowRelation follow)
        {
            _db.FollowRelations.Add(follow);
        }
        public void Remove(FollowRelation follow)
        {
            _db.FollowRelations.Remove(follow);
        }

        public async Task<List<GGuser>> GetMessageUsersRelation(int userid)
        {
            return await _db.Users
                .Where(g => g.Followers.Select(fo => fo.FollowerId)
                .Contains(userid) && g.Followees.Select(fo => fo.UserId)
                .Contains(userid)).ToListAsync();

        }
    }
}

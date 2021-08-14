using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories.Interfaces
{
    public interface IFollowRelationsRepository : IRepository<FollowRelation>
    {
        void Add(FollowRelation follow);
        Task<int> GetFollowersCount(int userid);
        Task<int> GetFollowingsCount(int userid);
        Task<FollowRelation> GetFollowRelationOfTwoUsers(int currentUserId, int requestedUserId);
        Task<FollowRelation> GetFollowRelationOfTwoUsersIncludingUser(int currentUserId, int requestedUserId);
        Task<int> GetFollowRelationsCountForOneUser(int userId);
        Task<List<GGuser>> GetMessageUsersRelation(int userid);
        void Remove(FollowRelation follow);
    }
}
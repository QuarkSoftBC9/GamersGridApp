using GamersGridApp.Models;
using System.Collections.Generic;

namespace GamersGridApp.Repositories
{
    public interface IFollowsRepository
    {
        void Add(Follow follow);
        int GetFollowersCount(int userid);
        int GetFollowingsCount(int userid);
        Follow GetFollowRelationOfTwoUsers(int currentUserId, int requestedUserId);
        Follow GetFollowRelationOfTwoUsersIncludingUser(int currentUserId, int requestedUserId);
        int GetFollowsCountForOneUser(int userId);
        List<User> GetMessageUsersRelation(int userid);
        void Remove(Follow follow);
    }
}
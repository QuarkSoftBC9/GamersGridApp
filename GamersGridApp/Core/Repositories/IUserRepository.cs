using GamersGridApp.Core.Models;
using System.Collections.Generic;

namespace GamersGridApp.Core.Repositories
{
    public interface IUserRepository
    {
        void AddUserPost(UserPosting userPosting);
        List<User> BetterSearchUsers(string searchstring);
        List<User> GetFollowersOfTwoUsersWithTheirFollowees(int userId1, int userId2);
        User GetLoggedUser(string loggedUserId);
        List<ApplicationUser> GetOtherUsers(string loggeduserid);
        User GetUser(int? userid);
        User GetUser(string name);
        User GetUserContent(string appUserId);
        int GetUserIdBasedOnAppID(string id);
        List<User> GetUsers();
        List<User> SearchUsers(string searchstring);
    }
}
using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.DAL.Models.Identity;
using System.Collections.Generic;

namespace GamersGrid.BLL.Repositories.Interfaces
{
    public interface IGGUserRepository: IRepository<GGuser>
    {
        List<GGuser> BetterSearchUsers(string searchstring);
        List<GGuser> GetFollowersOfTwoUsersWithTheirFollowees(int userId1, int userId2);
        List<GGuser> GetOtherUsers(int loggeduserid);
        GGuser GetUser(int? userid);
        GGuser GetUser(string name);
        List<GGuser> GetUsers();
        List<GGuser> SearchUsers(string searchstring);
    }
}
using GamersGridApp.Core.Models;
using System.Collections.Generic;

namespace GamersGridApp.Core.Repositories
{
    public interface IUserGameRepository
    {
        void Add(UserGame userGame);
        IEnumerable<int> GetGamesIdFocus(Game game);
        UserGame GetGameStatsByUser(int userid);
        Dictionary<string, GameAccountStats> GetGamesTitlesDict(List<UserGame> usergamelist, int userid);
        UserGame GetUserGameRelationWithExistingGame(int gameid, int userid);
        UserGame GetUserGameRelationWithExistingGameWithStats(int gameid, int userid);
        List<UserGame> GetUserGamesStats(int userid);
    }
}
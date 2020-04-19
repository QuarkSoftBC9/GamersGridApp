using GamersGridApp.Core.Models;
using System.Collections.Generic;

namespace GamersGridApp.Core.Repositories
{
    public interface IGameAccountStatsRepository
    {
        GameAccountStats GetGameAccStatsByID(int id);
        List<GameAccountStats> GetBestGameAccStatsByGameID(int gameId);
    }
}
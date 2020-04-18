using GamersGridApp.Core.Models;

namespace GamersGridApp.Core.Repositories
{
    public interface IGameAccountStatsRepository
    {
        GameAccountStats GetGameAccStatsByID(int id);
    }
}
using GamersGridApp.Models;

namespace GamersGridApp.Repositories
{
    public interface IGameAccountStatsRepository
    {
        GameAccountStats GetGameAccStatsByID(int id);
    }
}
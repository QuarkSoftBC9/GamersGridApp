using GamersGrid.BLL.Interfaces.Abstractions;
using GamersGrid.DAL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories.Interfaces
{
    public interface IGameAccountStatsRepository : IRepository<GameAccountStats>
    {
        Task<List<GameAccountStats>> GetBestGameAccStatsByGameID(int gameId);
        Task<GameAccountStats> GetGameAccStatsByID(int id);
    }
}
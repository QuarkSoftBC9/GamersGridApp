using GamersGridApp.Core.Models;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.Repositories
{
    public class GameAccountStatsRepository : IGameAccountStatsRepository
    {
        private readonly ApplicationDbContext _context;

        public GameAccountStatsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public GameAccountStats GetGameAccStatsByID(int id)
        {
            return _context.GameAccountStats
                .Where(gs => gs.Id == id).SingleOrDefault();
        }

        public List<GameAccountStats> GetBestGameAccStatsByGameID(int gameId)
        {
            return _context.GameAccountStats
                .Where(g => g.GameAccount.UserGame.GameID == gameId)
                .Include(g => g.GameAccount.UserGame.User)
                .OrderByDescending(g => g.Wins)
                .Take(20)
                .ToList();
        }


    }
}
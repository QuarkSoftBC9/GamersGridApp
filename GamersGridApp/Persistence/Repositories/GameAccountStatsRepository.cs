using GamersGridApp.Core.Models;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Persistence;
using System.Collections.Generic;
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
    }
}
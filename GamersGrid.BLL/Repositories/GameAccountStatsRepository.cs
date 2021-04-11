using GamersGrid.BLL.Repositories.Abstractions;
using GamersGrid.DAL;
using GamersGrid.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories
{
    public class GameAccountStatsRepository : Repository<GameAccountStatsRepository>
    {
        public GameAccountStatsRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<GameAccountStats> GetGameAccStatsByID(int id)
        {
            return await _db.GameAccountsStats
                .Where(gs => gs.GameAccountId == id).SingleOrDefaultAsync();
        }

        public async Task<List<GameAccountStats>> GetBestGameAccStatsByGameID(int gameId)
        {
            return await _db.GameAccountsStats
                .Where(g => g.GameAccount.GameId == gameId)
                .Include(g => g.GameAccount.User)
                .OrderByDescending(g => g.Wins)
                .Take(20)
                .ToListAsync();
        }
    }
}

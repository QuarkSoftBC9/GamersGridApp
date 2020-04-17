using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Repositories
{
    public class UserGameRepository
    {
        private readonly ApplicationDbContext _context;

        public UserGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserGame> GetUserGamesStats(int userid)
        {
            return _context.UserGameRelations
                .Where(u => u.UserId == userid)
                .Include(g => g.Game)
                .Include(ga => ga.GameAccount)
                .Include(gs => gs.GameAccount.GameAccountStats).ToList();
        }
        public Dictionary<string,GameAccountStats> GetGamesTitlesDict(List<UserGame> usergamelist,int userid)
        {
            return usergamelist
                .Where(u => u.UserId == userid)
                .Select(ga => ga.GameAccount.GameAccountStats)
                .ToDictionary(g => g.GameAccount.UserGame.Game.Title);
        }


    }
}
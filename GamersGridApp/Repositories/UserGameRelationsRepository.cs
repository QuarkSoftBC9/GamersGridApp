using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Repositories
{
    public class UserGameRelationsRepository
    {
        private readonly ApplicationDbContext _context;

        public UserGameRelationsRepository(ApplicationDbContext context)
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
        public IEnumerable<int> GetGamesIdFocus(Game game)
        {
            return _context.UserGameRelations.
                Where(g => g.Game.Title == game.Title && g.IsFavoriteGame == true)
                .Select(g => g.GameID).ToList();
        }
        public UserGame GetUserGameRelationWithExistingGame(int gameid,int userid)
        {
           return  _context.UserGameRelations
                           .Where(ugr => ugr.GameID == gameid && ugr.UserId == userid)
                           .Include(ugr => ugr.GameAccount)
                           .SingleOrDefault();
        }

    }
}
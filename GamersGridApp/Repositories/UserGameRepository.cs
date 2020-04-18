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

        public IEnumerable<int> GetGamesIdFocus(Game game)
        {
            return _context.UserGameRelations.
                Where(g => g.Game.Title == game.Title && g.IsFavoriteGame == true)
                .Select(g => g.GameID).ToList();
        }
        public UserGame GetUserGameRelationWithExistingGame(int gameid, int userid)
        {
            return _context.UserGameRelations
                            .Where(ugr => ugr.GameID == gameid && ugr.UserId == userid)
                            .Include(ugr => ugr.GameAccount)
                            .Include(ugr => ugr.GameAccount.GameAccountStats)
                            .SingleOrDefault();
        }
        public UserGame GetUserGameRelationWithExistingGameWithStats(int gameid, int userid)
        {
            return _context.UserGameRelations
                            .Where(ugr => ugr.GameID == gameid && ugr.UserId == userid)
                            .Include(ugr => ugr.GameAccount)
                            .Include(ga => ga.GameAccount.GameAccountStats)
                            .SingleOrDefault();
        }
        public UserGame GetGameStatsByUser(int userid)
        {
            return _context.UserGameRelations
                      .Include(ug => ug.GameAccount)
                      .Include(ug => ug.GameAccount.GameAccountStats)
                      .SingleOrDefault(ug => ug.GameID == 2 && ug.UserId == userid);
        }

        public void Add(UserGame userGame)
        {
            _context.UserGameRelations.Add(userGame);

        }
    }
}
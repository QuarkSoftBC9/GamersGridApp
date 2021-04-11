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
    public class UserGameRelationsRepository : Repository<UsersGamesRelation>
    {
        public UserGameRelationsRepository(ApplicationDbContext db) : base(db)
        {
        }


        //public List<UsersGamesRelation> GetUserGamesStats(int userid)
        //{
        //    return _db.UsersGamesRelations
        //        .Where(u => u.UserId == userid)
        //        .Include(g => g.Game)
        //        .Include(ga => ga.GameAccount)
        //        .Include(gs => gs.GameAccount.GameAccountStats).ToList();
        //}
        //public Dictionary<string, GameAccountStats> GetGamesTitlesDict(List<UsersGamesRelation> usergamelist, int userid)
        //{
        //    return usergamelist
        //        .Where(u => u.UserId == userid)
        //        .Select(ga => ga.GameAccount.GameAccountStats)
        //        .ToDictionary(g => g.GameAccount.UserGame.Game.Title);
        //}

        public async Task<IEnumerable<int>> GetGamesIdFocus(VideoGame game)
        {
            return await _db.UsersGamesRelations
                .Where(g => g.Game.Title == game.Title && g.IsFavoriteGame == true)
                .Select(g => g.GameId).ToListAsync();
        }
        //public UsersGamesRelation GetUserGameRelationWithExistingGame(int gameid, int userid)
        //{
        //    return _db.UsersGamesRelations
        //                    .Where(ugr => ugr.GameId == gameid && ugr.UserId == userid)
        //                    .Include(ugr => ugr.GameAccount)
        //                    .Include(ugr => ugr.GameAccount.GameAccountStats)
        //                    .SingleOrDefault();
        //}
        //public async Task<UsersGamesRelation> GetUserGameRelationWithExistingGameWithStats(int gameid, int userid)
        //{
        //    return _db.UsersGamesRelations
        //                    .Where(ugr => ugr.GameId == gameid && ugr.UserId == userid)
        //                    .Include(ugr => ugr.Game)
        //                    .Include(ga => ga.stats)
        //                    .SingleOrDefault();
        //}
        //public UsersGamesRelation GetGameStatsByUser(int userid)
        //{
        //    return _db.UsersGamesRelations
        //              .Include(ug => ug.GameAccount)
        //              .Include(ug => ug.GameAccount.GameAccountStats)
        //              .SingleOrDefault(ug => ug.GameID == 2 && ug.UserId == userid);
        //}

        public void Add(UsersGamesRelation userGame)
        {
            _db.UsersGamesRelations.Add(userGame);

        }
    }
}

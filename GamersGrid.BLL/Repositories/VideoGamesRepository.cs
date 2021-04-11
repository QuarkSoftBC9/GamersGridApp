using GamersGrid.BLL.Repositories.Abstractions;
using GamersGrid.DAL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories
{
    public class VideoGamesRepository : Repository<VideoGamesRepository>
    {
        public VideoGamesRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<VideoGame> GetFavouriteGame(int favoriteGameId)
        {
            return await _db.Games
               .SingleAsync(g => g.Id == favoriteGameId);
        }
        public async Task<int> GetFavouriteGameId(int UserId)
        {
            return await _db.UsersGamesRelations
                                .Where(u => u.UserId == UserId && u.IsFavoriteGame == true)
                                .Select(g => g.GameId)
                                .SingleOrDefaultAsync();
        }
        public async Task<string> GetFavouriteGameTitle(int favoriteGameId)
        {
            return await _db.Games
               .Where(g => g.Id == favoriteGameId)
               .Select(g => g.Title).SingleOrDefaultAsync();
        }

        public async Task<VideoGame> GetGame(string title)
        {
            return await _db.Games
                .SingleOrDefaultAsync(g => g.Title.Contains(title));
        }
        public async Task<int> GetGameId(string title)
        {
            return await _db.Games
                .Where(g => g.Title == title)
                .Select(g => g.Id)
                .SingleOrDefaultAsync();
        }

        //public UsersGamesRelation GetUserGameById(GGuser usercontent, int id)
        //{
        //    return usercontent.UserGames
        //        .SingleOrDefault(g => g.Id == id);
        //}
    }
}

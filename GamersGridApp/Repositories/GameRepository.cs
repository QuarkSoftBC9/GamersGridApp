using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace GamersGridApp.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ApplicationDbContext _context;


        public GameRepository(ApplicationDbContext context)
        {
            _context = context;

        }
        public IQueryable<Game> GetGames()
        {
            return _context.Games.AsQueryable();
        }
        public Game GetFavouriteGame(int favoriteGameId)
        {
            return _context.Games
               .Single(g => g.ID == favoriteGameId);
        }
        public int GetFavouriteGameId(int UserId)
        {
            return _context.UserGameRelations
                                .Where(u => u.UserId == UserId && u.IsFavoriteGame == true)
                                .Select(g => g.GameID)
                                .SingleOrDefault();
        }
        public string GetFavouriteGameTitle(int favoriteGameId)
        {
            return _context.Games
               .Where(g => g.ID == favoriteGameId)
               .Select(g => g.Title).SingleOrDefault();
        }

        public Game GetGame(string title)
        {
            return _context.Games
                .SingleOrDefault(g => g.Title.Contains(title));
        }
        public int GetGameId(string title)
        {
            return _context.Games
                .Where(g => g.Title == title)
                .Select(g => g.ID)
                .SingleOrDefault();
        }

        public UserGame GetUserGameById(User usercontent, int id)
        {
            return usercontent.UserGames
                .SingleOrDefault(g => g.Id == id);
        }




    }
}
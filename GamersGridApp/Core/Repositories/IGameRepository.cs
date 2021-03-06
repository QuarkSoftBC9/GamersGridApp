﻿using GamersGridApp.Core.Models;
using System.Linq;

namespace GamersGridApp.Core.Repositories
{
    public interface IGameRepository
    {
        Game GetFavouriteGame(int favoriteGameId);
        int GetFavouriteGameId(int UserId);
        string GetFavouriteGameTitle(int favoriteGameId);
        Game GetGame(string title);
        int GetGameId(string title);
        IQueryable<Game> GetGames();
        UserGame GetUserGameById(User usercontent, int id);
        
    }
}
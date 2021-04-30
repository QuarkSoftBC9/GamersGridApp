using GamersGrid.BLL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Controllers
{
    public class GameController : Controller
    {

        private readonly IUnitOfWork UnitOfWork;
        private readonly ILogger<GameController> logger;

        public GameController(IUnitOfWork unitofwork,ILogger<GameController> _logger)
        {
            UnitOfWork = unitofwork;
            logger = _logger;
        }
        // GET: Game
        public async Task<ViewResult> Index()
        {
            var games = await UnitOfWork.Games.GetAll();
            return View(games);
        }

        public async Task<ViewResult> About(string gameName)
        {
            //if (gameName == null)
            //    return RedirectToAction("Index");

            //var game = dbContext.Games.SingleOrDefault(g => g.Title == gameName);

            //if(game == null)
            //    return RedirectToAction("Index");

            //testing
            //var gameTest = dbContext.Games.SingleOrDefault(g => g.Title.Contains(gameName));
            var game = await UnitOfWork.Games.GetGameAsync(gameName);

            //var usersFocusing = dbContext.UserGameRelations.Where(g => g.Game.Title == gameTest.Title && g.IsFavoriteGame == true).Select(g => g.GameID).ToList();
            //var usersFocusing = UnitOfWork.UserGames.GetGamesIdFocus(gameTest);

            //var numberOfUsersFocusing = usersFocusing.Count();

            //var profileGame = new ProfileGameViewModel()
            //{
            //    Game = gameTest,
            //    UsersFocusing = numberOfUsersFocusing
            //};
            return View("GameProfile",game);
        }
    }
}

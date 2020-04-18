using GamersGridApp.Models;
using GamersGridApp.Perstistence;
using GamersGridApp.Repositories;
using GamersGridApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamersGridApp.Controllers
{
    public class GameController : Controller
    {

        private ApplicationDbContext dbContext;
        private readonly IGameRepository gameRepository;
        private readonly IUserGameRepository userGameRelationsRepository;
        private readonly UnitOfWork unitOfWork;


        public GameController()
        {
            dbContext = new ApplicationDbContext();
            gameRepository = new GameRepository(dbContext);
            userGameRelationsRepository = new UserGameRepository(dbContext);
            unitOfWork = new UnitOfWork(dbContext);

        }
        // GET: Game
        public ViewResult Index()
        {
            var games = dbContext.Games.ToList();
            return View("Games", games);
            //return View("GamesList");
        }


        public ActionResult GameProfile(string gameName)
        {
            //if (gameName == null)
            //    return RedirectToAction("Index");

            //var game = dbContext.Games.SingleOrDefault(g => g.Title == gameName);

            //if(game == null)
            //    return RedirectToAction("Index");

            //testing
            //var gameTest = dbContext.Games.SingleOrDefault(g => g.Title.Contains(gameName));
            var gameTest = gameRepository.GetGame(gameName);

            //var usersFocusing = dbContext.UserGameRelations.Where(g => g.Game.Title == gameTest.Title && g.IsFavoriteGame == true).Select(g => g.GameID).ToList();
            var usersFocusing = userGameRelationsRepository.GetGamesIdFocus(gameTest);

            var numberOfUsersFocusing = usersFocusing.Count();

            var profileGame = new ProfileGameViewModel()
            {
                Game = gameTest,
                UsersFocusing = numberOfUsersFocusing
            };
            return View(profileGame);
        }
    }
}
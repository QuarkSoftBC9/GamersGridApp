using GamersGridApp.Models;
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

        public GameController()
        {
            dbContext = new ApplicationDbContext();
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
            var gameTest = dbContext.Games.SingleOrDefault(g => g.Title == gameName);
            var usersFocusing = dbContext.UserGameRelations.Where(g => g.Game.Title == gameName && g.IsFavoriteGame == true).Select(g => g.GameID).ToList();
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
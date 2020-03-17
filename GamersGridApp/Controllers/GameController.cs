using GamersGridApp.Models;
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
            return View("GamesList");
        }


        public ActionResult GameProfile(string gameName)
        {
            //if (gameName == null)
            //    return RedirectToAction("Index");

            //var game = dbContext.Games.SingleOrDefault(g => g.Title == gameName);

            //if(game == null)
            //    return RedirectToAction("Index");

            //testing
            var gameTest = dbContext.Games.SingleOrDefault();
            return View(gameTest);
        }
    }
}
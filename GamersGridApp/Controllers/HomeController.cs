using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamersGridApp.ViewModels;
using GamersGridApp.Models;
using System.Web.Http;

namespace GamersGridApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext context;
        // MyDbContext();
        //Uncomment for costum DbContext
        public HomeController()
        {
            context = new ApplicationDbContext();
            // context = new MyDbContext();
            // Uncomment for costum DbContext
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        public ActionResult Index(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                return RedirectToAction("Search", new {searchString = search });
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search([FromBody]string searchString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                List<User> usersSearched = context.GamersGridUsers
                    .Where(u => u.NickName.Contains(searchString)
                || u.FirstName.Contains(searchString)
                || u.LastName.Contains(searchString))
                    .Take(40)
                    .ToList();
                List<Game> gamesSearched = context.Games
                    .Where(g => g.Title.Contains(searchString))
                    .ToList();
                SearchViewModel searchviewModel = new SearchViewModel(usersSearched, gamesSearched, (usersSearched.Count > 0), (gamesSearched.Count > 0)) { };
                return View(searchviewModel);
            }

            var games = context.Games.ToList();
            //var users = context.Users.ToList().Take(40);
            //var users = GamersGridApp.Models.User.GetUsers(); // Just as a test data for now 
            var searchviewModelEmpty = new SearchViewModel(new List<User>(), games, false, true);

            return View(searchviewModelEmpty);
        }
    }
}
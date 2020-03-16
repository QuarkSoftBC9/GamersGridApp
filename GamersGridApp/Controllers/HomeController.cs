using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamersGridApp.ViewModels;
using GamersGridApp.Models;

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
        public ActionResult Search(string searchString)
        {
            SearchViewModel searchviewModel = new SearchViewModel() { };

            //ERROR The specified type member 'FullName' is not supported in LINQ to Entities. Only initializers, entity members, and entity navigation properties are supported.
            //List<User> users = context.GamersGridUsers.Where(u => u.NickName.Contains(searchString) || u.FullName.Contains(searchString)).Take(50).ToList();
            //List<Game> games = context.Games.Where(g => g.Title.Contains(searchString)).ToList();
            var games = context.Games.ToList();
            var users = GamersGridApp.Models.User.GetUsers();
            if (games.Count > 0)
            {
                searchviewModel.Games= games;
                searchviewModel.HasGames = true;

            }
            searchviewModel.Games.Add(games[0]);
            if (users.Count > 0)
            {
                searchviewModel.Users = users;
                searchviewModel.HasUsers = true;
            }

            //testing game 
            //searchviewModel.Games = context.Games;
            return View(searchviewModel);
            //return View(searchviewModel);
        }
    }
}
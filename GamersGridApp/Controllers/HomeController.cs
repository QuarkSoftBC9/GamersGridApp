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
        //public ActionResult Search(string searchString)
        //{
        //    //SearchViewModel searchviewModel = new SearchViewModel() { };

        //    List<User> users = context.GamersGridUsers.Where(u => u.NickName.Contains(searchString) || u.FullName.Contains(searchString)).Take(50).ToList();
        //    List<Game> games = context.Games.Where(g => g.Title.Contains(searchString)).ToList();

        //    //if(games.Count > 0)
        //    //{
        //    //    searchviewModel.Games.AddRange(games);
        //    //    searchviewModel.HasGames = true;
        //    //}
                
        //    //if (users.Count > 0)
        //    //{
        //    //    searchviewModel.Users.AddRange(users);
        //    //    searchviewModel.HasUsers = true;
        //    //}

        //    //return View(searchviewModel);
        //}
    }
}
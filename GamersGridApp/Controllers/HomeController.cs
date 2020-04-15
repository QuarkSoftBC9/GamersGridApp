using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GamersGridApp.ViewModels;
using GamersGridApp.Models;
using System.Web.Http;
using Microsoft.AspNet.Identity;

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
        public ActionResult GamersStats()
        {

            return View();
        }

        public ActionResult AvraamGamers()
        {
            List<User> otherUsers;

                //var viewModel = new PlayersListViewModel();


                //    dict = dt.DataValues.Where(d => sensorIDs.Contains(d.SensorID))
                //    .GroupBy(a => a.DataID)
                //     .Join(dt.Datas, a => a.Key, a => a.DataId,
                //            (a, b) => new { Key = b, Value = a.ToList() })
                //.ToDictionary(a => a.Key, a => a.Value);

                //Getting the user
                //if (User.Identity.IsAuthenticated)
                //{
                //    var userId = User.Identity.GetUserId();
                //    var user = context.Users.Where(d => d.Id == userId).Select(d => d.UserAccount).SingleOrDefault();

                //    //Show User except the one who is logged in
                //    otherUsers = context.GamersGridUsers.Where(u => u.ID != user.ID).ToList();
                //    Dictionary<int, string> DictionaryForViewModel = new Dictionary<int, string>();
                //    foreach (var userGamer in otherUsers)
                //    {
                //        var favoriteGameId = context.UserGameRelations
                //                    .Where(u => u.UserId == userGamer.ID && u.IsFavoriteGame == true)
                //                    .Select(g => g.GameID)
                //                    .SingleOrDefault();

                //        var favoriteGameTitle = context.Games
                //                    .Where(g => g.ID == favoriteGameId)
                //                    .Select(g => g.Title)
                //                    .SingleOrDefault();

                //        DictionaryForViewModel.Add(userGamer.ID, favoriteGameTitle);
                //    }

                //}
                //else

                otherUsers = context.GamersGridUsers.ToList();
                Dictionary<int, string> DictionaryForViewModel = new Dictionary<int, string>();

                foreach (var userGamer in otherUsers)
                {
                    var favoriteGameId = context.UserGameRelations
                                .Where(u => u.UserId == userGamer.ID && u.IsFavoriteGame == true)
                                .Select(g => g.GameID)
                                .SingleOrDefault();

                    var favoriteGameTitle = context.Games
                                .Where(g => g.ID == favoriteGameId)
                                .Select(g => g.Title)
                                .SingleOrDefault();

                    DictionaryForViewModel.Add(userGamer.ID, favoriteGameTitle);
                }
                var viewModel = new PlayersListViewModel()
                {
                    Users = otherUsers,
                    UserFavoriteGame = DictionaryForViewModel

                };
               
            
            return View(viewModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Search([FromBody]string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
                return HttpNotFound();

            // We can create a custom page to return as view in case of empty string
            // or redirect to games page

            var game = context.Games.SingleOrDefault(g => g.Title.Contains(searchString));

            if (game != null)
               return  RedirectToAction("GameProfile", "Game", new { gameName = game.Title });

            var users = context.GamersGridUsers.Where(ggu => ggu.NickName.Contains(searchString)).ToList();
            
            if (users.Count == 0) 
                return HttpNotFound();
           
            if (users.Count == 1)
                return RedirectToAction("ProfilePage", "User", new { userid = users[0].ID });

            return RedirectToAction("AvraamGamers");

            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    List<User> usersSearched = context.GamersGridUsers
            //        .Where(u => u.NickName.Contains(searchString)
            //    || u.FirstName.Contains(searchString)
            //    || u.LastName.Contains(searchString))
            //        .Take(40)
            //        .ToList();
            //    List<Game> gamesSearched = context.Games
            //        .Where(g => g.Title.Contains(searchString))
            //        .ToList();
            //    SearchViewModel searchviewModel = new SearchViewModel(usersSearched, gamesSearched, (usersSearched.Count > 0), (gamesSearched.Count > 0)) { };
            //    return View(searchviewModel);
            //}

            //var games = context.Games.ToList();
            ////var users = context.Users.ToList().Take(40);
            ////var users = GamersGridApp.Models.User.GetUsers(); // Just as a test data for now 
            //var searchviewModelEmpty = new SearchViewModel(new List<User>(), games, false, true);

            //return View(searchviewModelEmpty);
        }
    }
}
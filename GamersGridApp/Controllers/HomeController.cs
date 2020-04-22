using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Http;

using System.Data.Entity;
using GamersGridApp.Core;
using GamersGridApp.Core.Models;
using GamersGridApp.Core.ViewModels;

namespace GamersGridApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork UnitOfWork;
        // MyDbContext();
        //Uncomment for costum DbContext
        public HomeController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;

            // context = new MyDbContext();
            // Uncomment for costum DbContext
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    
    public ActionResult SearchEngine()
    {
            var viewModel = new SearchEngineViewModel();
        return View(viewModel);
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

        public ActionResult Gamers()
        {
            List<User> otherUsers;


            otherUsers = UnitOfWork.GGUsers.GetUsers();
                Dictionary<int, string> DictionaryForViewModel = new Dictionary<int, string>();

                foreach (var userGamer in otherUsers)
                {
                //var favoriteGameId = context.UserGameRelations
                //            .Where(u => u.UserId == userGamer.ID && u.IsFavoriteGame == true)
                //            .Select(g => g.GameID)
                //            .SingleOrDefault();

                    var favoriteGameId = UnitOfWork.Games.GetFavouriteGameId(userGamer.ID);

                //var favoriteGameTitle = context.Games
                //            .Where(g => g.ID == favoriteGameId)
                //            .Select(g => g.Title)
                //            .SingleOrDefault();

                   var favoriteGameTitle = UnitOfWork.Games.GetFavouriteGameTitle(favoriteGameId);

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
            //if (string.IsNullOrEmpty(searchString))
            //    return HttpNotFound();

            // We can create a custom page to return as view in case of empty string
            // or redirect to games page
            if (!string.IsNullOrWhiteSpace(searchString))
            {
                //var game = context.Games.FirstOrDefault(g => g.Title.Contains(searchString));
                var game = UnitOfWork.Games.GetGame(searchString);

                if (game != null)
                    return RedirectToAction("GameProfile", "Game", new { gameName = game.Title });

                //var users = context.GamersGridUsers.Where(ggu => ggu.NickName.Contains(searchString)).ToList();

                var users = UnitOfWork.GGUsers.SearchUsers(searchString);

                //if (users.Count == 0) 
                //    return HttpNotFound();

                if (users.Count == 1)
                    return RedirectToAction("ProfilePage", "User", new { userid = users[0].ID });

            }

            return RedirectToAction("Gamers");


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

        public ViewResult Leaderboards()
        {

            //DOTA
            const int dotaId = 2;
            var BestDotaUsers = UnitOfWork.GameAccountStats.GetBestGameAccStatsByGameID(dotaId);

            //LOL
            const int lolId = 1;
            var BestLolUsers = UnitOfWork.GameAccountStats.GetBestGameAccStatsByGameID(lolId);

            //OVERWATCH
            const int overwatchId = 3;
            var BestOverWatchUsers = UnitOfWork.GameAccountStats.GetBestGameAccStatsByGameID(overwatchId);

            var LeaderBoardVM = new LeaderBoardViewModel()
            {
                TopDotaStats = BestDotaUsers,
                TopLolStats = BestLolUsers,
                TopOverwatchStats = BestOverWatchUsers
            };

            return View(LeaderBoardVM);

        }
    }
}
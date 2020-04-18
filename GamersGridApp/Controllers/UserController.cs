
using GamersGridApp.Helpers;

using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data.Entity;
using GamersGridApp.Interfaces;
using GamersGridApp.Core;
using GamersGridApp.Core.ViewModels;
using GamersGridApp.Core.Models;

namespace GamersGridApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;



        public UserController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;


        }

        // GET: User
        public ViewResult Index()
        {

            return View("UsersList");
        }

        public ActionResult NewsFeed()
        {
            //Getting the user
            var userId = User.Identity.GetUserId();

            //var user = context.Users.Where(d => d.Id == userId).Select(d => d.UserAccount).SingleOrDefault();
            var user = UnitOfWork.GGUsers.GetLoggedUser(userId);

            //Getting All notifications
            //var notifications = context.UserNotifications
            //              .Where(un => un.UserId == user.ID && !un.IsRead)
            //              .Include(un => un.Notification)
            //              .Select(n => n.Notification)
            //              .ToList();

            var notifications = UnitOfWork.UserNotifications.GetUserNotifications(user.ID);

            List<INewsFeed> newsFeed = new List<INewsFeed>(notifications);
            return View(newsFeed.OrderBy(n => n.TimeStamp));
        }
        [Authorize]
        public ActionResult ProfilePage(int? userid)
        {
            //current logged user 
            var loggedUserId = User.Identity.GetUserId();
            //var currentLoggedUser = context.Users.Where(u => u.Id == loggedUserId).Select(u => u.UserAccount).SingleOrDefault();
            var currentLoggedUser = UnitOfWork.GGUsers.GetLoggedUser(loggedUserId);

            //var user = (userid == null) ? currentLoggedUser : context.GamersGridUsers.SingleOrDefault(u => u.ID == userid);
            var user = (userid == null) ? currentLoggedUser : UnitOfWork.GGUsers.GetUser(userid);

            //var favoritegame = context.UserGames.Where(d => d.UserId == userId).Select(d => d.UserAccount).SingleOrDefault();

            //var favoritegameID = context.UserGameRelations.Where(u => u.UserId == user.ID && u.IsFavoriteGame == true).Select(g => g.GameID).SingleOrDefault();
            var favoritegameID = UnitOfWork.Games.GetFavouriteGameId(user.ID);

            //var favoritegame = context.Games.Include(g => g.ID == favoritegameID).SingleOrDefault();

            //var favoritegame = context.Games
            //  .Where(g => g.ID == favoritegameID)
            //  .SingleOrDefault();
            if (favoritegameID == 0)
                favoritegameID = 3;
            var favoritegame = UnitOfWork.Games.GetFavouriteGame(favoritegameID);

            if (user == null)
                return HttpNotFound();

            //preparing viewmodel of searched user
            var viewModel = new UserProfilePageViewModel()
            {
                FollowsCount = UnitOfWork.Follows.GetFollowersCount(user.ID),
                FollowingCount = UnitOfWork.Follows.GetFollowingsCount(user.ID),
                User = user,
                FavouriteGame = favoritegame,
                FavoriteGameID = favoritegameID
            };

            //variables bound in viewmodel to be used for razor page logic between profile page and current logged user
            if (currentLoggedUser.ID == user.ID)
            {
                viewModel.IsCurrent = true;
                viewModel.LoggedUserId = currentLoggedUser.ID;
            }
            else
            {
                //var followRelation = context.Follows.SingleOrDefault(f => f.FollowerId == currentLoggedUser.ID && f.UserId == user.ID);
                var followRelation = UnitOfWork.Follows.GetFollowRelationOfTwoUsers(currentLoggedUser.ID, user.ID);
                if (followRelation == null)
                    viewModel.IsFollowing = false;
                else
                    viewModel.IsFollowing = true;

                viewModel.IsCurrent = false;
                viewModel.LoggedUserId = currentLoggedUser.ID;
            }
            //including stats 
            //var userGames = context.UserGameRelations
            //    .Where(u => u.UserId == user.ID)
            //    .Include(g => g.Game)
            //    .Include(ga => ga.GameAccount)
            //    .Include(gs => gs.GameAccount.GameAccountStats).ToList();

            var userGames = UnitOfWork.UserGames.GetUserGamesStats(user.ID);

            bool accountsFilled = true;

            foreach (var usergame in userGames)
            {
                if (usergame.GameAccount == null)
                    accountsFilled = false;
            }

            if (accountsFilled)
            {
                //viewModel.GamesStats = userGames
                //    .Where(u => u.UserId == user.ID)
                //    .Select(ga => ga.GameAccount.GameAccountStats)
                //    .ToDictionary(g => g.GameAccount.UserGame.Game.Title);

                viewModel.GamesStats = UnitOfWork.UserGames.GetGamesTitlesDict(userGames, user.ID);
            }

            return View(viewModel);
        }


        [Authorize]
        public ActionResult Customize()
        {
            var aspNetUserID = User.Identity.GetUserId();
            //var ggtUser = context.Users.Where(u => u.Id == aspNetUserID)
            //    .Select(c => c.UserAccount)
            //    .SingleOrDefault();
            var ggUser = UnitOfWork.GGUsers.GetLoggedUser(aspNetUserID);

            const int lolId = 1;
            const int dotaId = 2;
            const int overwatchId = 3;

            //var userGameRelationLol = context.UserGameRelations
            //    .Where(ugr => ugr.GameID == lolId && ugr.UserId == ggtUser.ID)
            //    .Include(ugr=>ugr.GameAccount)
            //    .SingleOrDefault();

            //var userGameRelationDota = context.UserGameRelations
            //   .Where(ugr => ugr.GameID == dotaId && ugr.UserId == ggtUser.ID)
            //   .Include(ugr => ugr.GameAccount)
            //   .SingleOrDefault();

            //var userGameRelationOverwatch = context.UserGameRelations
            //   .Where(ugr => ugr.GameID == overwatchId && ugr.UserId == ggtUser.ID)
            //   .Include(ugr => ugr.GameAccount)
            //   .SingleOrDefault();

            var userGameRelationLol = UnitOfWork.UserGames.GetUserGameRelationWithExistingGame(lolId, ggUser.ID);
            var userGameRelationDota = UnitOfWork.UserGames.GetUserGameRelationWithExistingGame(dotaId, ggUser.ID);
            var userGameRelationOverwatch = UnitOfWork.UserGames.GetUserGameRelationWithExistingGame(overwatchId, ggUser.ID);

            var viewmodel = new UserFormEditViewModel(ggUser, userGameRelationDota, userGameRelationLol, userGameRelationOverwatch);
            return View("Customize", viewmodel);

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserFormEditViewModel viewmodel, HttpPostedFileBase file)
        {
            //var userContent = context.GamersGridUsers
            //    .SingleOrDefault(u => u.ID == viewmodel.ID);
            var userContent = UnitOfWork.GGUsers.GetUser(viewmodel.ID);
            userContent.Update(
                viewmodel.FirstName, viewmodel.LastName, viewmodel.NickName,
                viewmodel.Description, viewmodel.Country, viewmodel.City);

            if (!(file is null))
            {
                userContent.Update(ExtraMethods.UploadPhoto(userContent.ID, file));
            }

            UnitOfWork.Complete();

            return RedirectToAction("ProfilePage", new { nickname = userContent.NickName });
        }
        //Get lolAccount
        public ActionResult LOLAccount()
        {
            //int lolID = context.Games
            //    .Where(g => g.Title == "League Of Legends")
            //    .Select(g => g.ID)
            //    .SingleOrDefault();
            int lolID = UnitOfWork.Games.GetGameId("League Of Legends");

            //check if the user is correct AspNetUser == User
            var appUserId = User.Identity.GetUserId();
            //var userContent = context.Users
            //    .Where(u => u.Id == appUserId)
            //    .Select(u => u.UserAccount)
            //    .Include(ug => ug.UserGames.Select(g => g.GameAccount))
            //    .SingleOrDefault();
            var userContent = UnitOfWork.GGUsers.GetUserContent(appUserId);

            //var userGame = userContent.UserGames.SingleOrDefault(g => g.Id == lolID);
            var userGame = UnitOfWork.Games.GetUserGameById(userContent, lolID);

            // instead of userGame != the check is done if a gameAcc exists or not
            if (userGame != null && userGame.GameAccount != null)
                return View(new AddLOLAccountViewmodel(userGame.GameAccount.NickName, userGame.GameAccount.AccountRegions));


            return View(new AddLOLAccountViewmodel());
        }
        ////Get OverWatch Account
        public ActionResult OverWatchAccount()
        {

            //int overwatchID = context.Games
            //    .Where(g => g.Title == "Overwatch")
            //    .Select(g => g.ID)
            //    .SingleOrDefault();
            int overwatchID = UnitOfWork.Games.GetGameId("Overwatch");


            var appUserId = User.Identity.GetUserId();
            //var userContent = context.Users
            //    .Where(u => u.Id == appUserId)
            //    .Select(u => u.UserAccount)
            //    .Include(ug => ug.UserGames.Select(g => g.GameAccount))
            //    .SingleOrDefault();
            var userContent = UnitOfWork.GGUsers.GetUserContent(appUserId);


            //var userGame = context.UserGameRelations
            //    .SingleOrDefault(ug => ug.UserId == userContent.ID && ug.GameID == overwatchID);
            var userGame = UnitOfWork.Games.GetUserGameById(userContent, overwatchID);

            if (userGame != null)
                return View(new AddOverwatchAccViewModel(userGame.GameAccount.AccountIdentifier, userGame.GameAccount.AccountRegions));
            return View(new AddOverwatchAccViewModel());
        }

        // Dota 2 Account
        public ActionResult DotaAccount()
        {


            int dotaID = UnitOfWork.Games.GetGameId("Dota 2");


            string appUserId = User.Identity.GetUserId();

            //int ggUserAccountId = context.Users.Where(u => u.Id == userId)
            //    .Select(u => u.UserAccount.ID)
            //    .SingleOrDefault();
            var userContent = UnitOfWork.GGUsers.GetUserContent(appUserId);

            //var userGame = context.UserGameRelations
            //    .Include(ug => ug.GameAccount)
            //    .SingleOrDefault(ug => ug.UserId == ggUserAccountId && ug.GameID == 3);

            var userGame = UnitOfWork.Games.GetUserGameById(userContent, dotaID);

            if (userGame == null)
                return View(new AddDotaAccountViewModel());

            return View(new AddDotaAccountViewModel(userGame.GameAccount.AccountIdentifier));
        }

        public ActionResult PostMessageEdit()
        {
            var appUserId = User.Identity.GetUserId();
            //var otherUsers = context.Users
            //    .Where(u => u.Id != appUserId)
            //    .ToList();

            var otherUsers = UnitOfWork.GGUsers.GetOtherUsers(appUserId);

            return View("PostMessage", new PostMessageViewModel(otherUsers));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostMessageSave(PostMessageViewModel viewModel)
        {
            var appUserId = User.Identity.GetUserId();
            //var posterid = context.Users.Where(u => u.Id == appUserId).Select(u => u.UserId).Single();
            var posterid = UnitOfWork.GGUsers.GetUserIdBasedOnAppID(appUserId);
            //context.UserPostings.Add(new UserPosting(viewModel.PostingMessage, viewModel.OwnerId, posterid));
            UnitOfWork.GGUsers.AddUserPost(new UserPosting(viewModel.PostingMessage, viewModel.OwnerId, posterid));
            UnitOfWork.Complete();


            return RedirectToAction("ProfilePage");
        }

        public ViewResult Leaderboards()
        {

            return View();
        }
    }
}
using AutoMapper;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Enums;
using GamersGridApp.Helpers;
using GamersGridApp.Models;
using GamersGridApp.ViewModels;
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
using GamersGridApp.Repositories;
using GamersGridApp.Perstistence;

namespace GamersGridApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        private readonly GameRepository gameRepository;
        private readonly UserGameRepository userGameRelationsRepository;
        private readonly UserRepository userRepository;
        private readonly UserNotificationRepository userNotificationRepository;
        private readonly FollowsRepository followsRepository;
        private readonly UnitOfWork unitOfWork;



        public UserController()
        {
            context = new ApplicationDbContext();
            gameRepository = new GameRepository(context);
            userGameRelationsRepository = new UserGameRepository(context);
            userRepository = new UserRepository(context);
            userNotificationRepository = new UserNotificationRepository(context);
            followsRepository = new FollowsRepository(context);
            unitOfWork = new UnitOfWork(context);


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
            var user = userRepository.GetLoggedUser(userId);

            //Getting All notifications
            //var notifications = context.UserNotifications
            //              .Where(un => un.UserId == user.ID && !un.IsRead)
            //              .Include(un => un.Notification)
            //              .Select(n => n.Notification)
            //              .ToList();

            var notifications = userNotificationRepository.GetUserNotifications(user.ID);

            List<INewsFeed> newsFeed = new List<INewsFeed>(notifications);
            return View(newsFeed.OrderBy(n => n.TimeStamp));
        }
        [Authorize]
        public ActionResult ProfilePage(int? userid)
        {
            //current logged user 
            var loggedUserId = User.Identity.GetUserId();
            //var currentLoggedUser = context.Users.Where(u => u.Id == loggedUserId).Select(u => u.UserAccount).SingleOrDefault();
            var currentLoggedUser = userRepository.GetLoggedUser(loggedUserId);

            //var user = (userid == null) ? currentLoggedUser : context.GamersGridUsers.SingleOrDefault(u => u.ID == userid);
            var user = (userid == null) ? currentLoggedUser : userRepository.GetUser(userid);

            //var favoritegame = context.UserGames.Where(d => d.UserId == userId).Select(d => d.UserAccount).SingleOrDefault();

            //var favoritegameID = context.UserGameRelations.Where(u => u.UserId == user.ID && u.IsFavoriteGame == true).Select(g => g.GameID).SingleOrDefault();
            var favoritegameID = gameRepository.GetFavouriteGameId(user.ID);

            //var favoritegame = context.Games.Include(g => g.ID == favoritegameID).SingleOrDefault();

            //var favoritegame = context.Games
            //  .Where(g => g.ID == favoritegameID)
            //  .SingleOrDefault();
            if (favoritegameID == 0)
                favoritegameID = 3;
            var favoritegame = gameRepository.GetFavouriteGame(favoritegameID);

            if (user == null)
                return HttpNotFound();

            //preparing viewmodel of searched user
            var viewModel = new UserProfilePageViewModel()
            {
                FollowsCount = context.Follows.Count(f => f.UserId == user.ID),
                FollowingCount = context.Follows.Count(f => f.FollowerId == user.ID),
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
                var followRelation = followsRepository.GetFollowRelationOfTwoUsers(currentLoggedUser.ID, user.ID);
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

            var userGames = userGameRelationsRepository.GetUserGamesStats(user.ID);

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

                viewModel.GamesStats = userGameRelationsRepository.GetGamesTitlesDict(userGames, user.ID);
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
            var ggtUser = userRepository.GetLoggedUser(aspNetUserID);

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

            var userGameRelationLol = userGameRelationsRepository.GetUserGameRelationWithExistingGame(lolId, ggtUser.ID);
            var userGameRelationDota = userGameRelationsRepository.GetUserGameRelationWithExistingGame(dotaId, ggtUser.ID);
            var userGameRelationOverwatch = userGameRelationsRepository.GetUserGameRelationWithExistingGame(overwatchId, ggtUser.ID);

            var viewmodel = new UserFormEditViewModel(ggtUser, userGameRelationDota, userGameRelationLol, userGameRelationOverwatch);
            return View("Customize", viewmodel);

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserFormEditViewModel viewmodel, HttpPostedFileBase file)
        {
            //var userContent = context.GamersGridUsers
            //    .SingleOrDefault(u => u.ID == viewmodel.ID);
            var userContent = userRepository.GetUser(viewmodel.ID);
            userContent.Update(
                viewmodel.FirstName, viewmodel.LastName, viewmodel.NickName,
                viewmodel.Description, viewmodel.Country, viewmodel.City);

            if (!(file is null))
            {
                userContent.Update(ExtraMethods.UploadPhoto(userContent.ID, file));
            }

            unitOfWork.Complete();

            return RedirectToAction("ProfilePage", new { nickname = userContent.NickName });
        }
        //Get lolAccount
        public ActionResult LOLAccount()
        {
            //int lolID = context.Games
            //    .Where(g => g.Title == "League Of Legends")
            //    .Select(g => g.ID)
            //    .SingleOrDefault();
            int lolID = gameRepository.GetGameId("League Of Legends");

            //check if the user is correct AspNetUser == User
            var appUserId = User.Identity.GetUserId();
            //var userContent = context.Users
            //    .Where(u => u.Id == appUserId)
            //    .Select(u => u.UserAccount)
            //    .Include(ug => ug.UserGames.Select(g => g.GameAccount))
            //    .SingleOrDefault();
            var userContent = userRepository.GetUserContent(appUserId);

            //var userGame = userContent.UserGames.SingleOrDefault(g => g.Id == lolID);
            var userGame = gameRepository.GetUserGameById(userContent, lolID);

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
            int overwatchID = gameRepository.GetGameId("Overwatch");


            var appUserId = User.Identity.GetUserId();
            //var userContent = context.Users
            //    .Where(u => u.Id == appUserId)
            //    .Select(u => u.UserAccount)
            //    .Include(ug => ug.UserGames.Select(g => g.GameAccount))
            //    .SingleOrDefault();
            var userContent = userRepository.GetUserContent(appUserId);


            //var userGame = context.UserGameRelations
            //    .SingleOrDefault(ug => ug.UserId == userContent.ID && ug.GameID == overwatchID);
            var userGame = gameRepository.GetUserGameById(userContent, overwatchID);

            if (userGame != null)
                return View(new AddOverwatchAccViewModel(userGame.GameAccount.AccountIdentifier, userGame.GameAccount.AccountRegions));
            return View(new AddOverwatchAccViewModel());
        }

        // Dota 2 Account
        public ActionResult DotaAccount()
        {


            int dotaID = gameRepository.GetGameId("Dota 2");


            string appUserId = User.Identity.GetUserId();

            //int ggUserAccountId = context.Users.Where(u => u.Id == userId)
            //    .Select(u => u.UserAccount.ID)
            //    .SingleOrDefault();
            var userContent = userRepository.GetUserContent(appUserId);

            //var userGame = context.UserGameRelations
            //    .Include(ug => ug.GameAccount)
            //    .SingleOrDefault(ug => ug.UserId == ggUserAccountId && ug.GameID == 3);

            var userGame = gameRepository.GetUserGameById(userContent, dotaID);

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

            var otherUsers = userRepository.GetOtherUsers(appUserId);

            return View("PostMessage", new PostMessageViewModel(otherUsers));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostMessageSave(PostMessageViewModel viewModel)
        {
            var appUserId = User.Identity.GetUserId();
            //var posterid = context.Users.Where(u => u.Id == appUserId).Select(u => u.UserId).Single();
            var posterid = userRepository.GetUserIdBasedOnAppID(appUserId);
            //context.UserPostings.Add(new UserPosting(viewModel.PostingMessage, viewModel.OwnerId, posterid));
            userRepository.AddUserPost(new UserPosting(viewModel.PostingMessage, viewModel.OwnerId, posterid));
            unitOfWork.Complete();


            return RedirectToAction("ProfilePage");
        }

        public ViewResult Leaderboards()
        {

            return View();
        }
    }
}
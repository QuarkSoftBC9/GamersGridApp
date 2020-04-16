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

namespace GamersGridApp.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();

        public UserController()
        {
            context = new ApplicationDbContext();
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
            var user = context.Users.Where(d => d.Id == userId).Select(d => d.UserAccount).SingleOrDefault();

            //Getting All notifications
            var notifications = context.UserNotifications
                          .Where(un => un.UserId == user.ID && !un.IsRead)
                          .Include(un => un.Notification)
                          .Select(n => n.Notification)
                          .ToList();


            List<INewsFeed> newsFeed = new List<INewsFeed>(notifications);
            return View(newsFeed.OrderBy(n => n.TimeStamp));
        }
        [Authorize]
        public ActionResult ProfilePage(int? userid)
        {
            //current logged user 
            var loggedUserId = User.Identity.GetUserId();
            var currentLoggedUser = context.Users.Where(u => u.Id == loggedUserId).Select(u => u.UserAccount).SingleOrDefault();

            var user = (userid == null) ? currentLoggedUser : context.GamersGridUsers.SingleOrDefault(u => u.ID == userid);

            //var favoritegame = context.UserGames.Where(d => d.UserId == userId).Select(d => d.UserAccount).SingleOrDefault();

            var favoritegameID = context.UserGameRelations.Where(u => u.UserId == user.ID && u.IsFavoriteGame == true).Select(g => g.GameID).SingleOrDefault();
            //var favoritegame = context.Games.Include(g => g.ID == favoritegameID).SingleOrDefault();

            var favoritegame = context.Games
              .Where(g => g.ID == favoritegameID)
              .SingleOrDefault();

            if (user == null)
                return HttpNotFound();

            //preparing viewmodel of searched user
            var viewModel = new UserProfilePageViewModel()
            {
                FollowsCount = context.Follows.Count(f => f.UserId == user.ID),
                FollowingCount = context.Follows.Count(f => f.FollowerId == user.ID),
                User = user,
            };

            //variables bound in viewmodel to be used for razor page logic between profile page and current logged user
            if (currentLoggedUser.ID == user.ID)
            {
                viewModel.IsCurrent = true;
                viewModel.LoggedUserId = currentLoggedUser.ID;
            }
            else
            {
                var followRelation = context.Follows.SingleOrDefault(f => f.FollowerId == currentLoggedUser.ID && f.UserId == user.ID);
                if (followRelation == null)
                    viewModel.IsFollowing = false;
                else
                    viewModel.IsFollowing = true;

                viewModel.IsCurrent = false;
                viewModel.LoggedUserId = currentLoggedUser.ID;
            }
            //including stats 
            var userGame = context.UserGameRelations
                .Where(u => u.UserId == user.ID)
                .Include(g => g.Game)
                .Include(ga => ga.GameAccount)
                .Include(gs => gs.GameAccount.GameAccountStats).ToList();

            viewModel.GamesStats = userGame
                .Where(u => u.UserId == user.ID)
                .Select(ga => ga.GameAccount.GameAccountStats)
                .ToDictionary(g => g.GameAccount.UserGame.Game.Title);

            return View(viewModel);
        }

        ////Get
        //[Authorize]
        ////[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id)
        //{
        //    var aspNetUserID = User.Identity.GetUserId();
        //    var aspNetUser = context.Users.Where(u => u.Id == aspNetUserID)
        //        .Include(c => c.UserAccount)
        //        .SingleOrDefault();
        //    //var userContent = context.GamersGridUsers.SingleOrDefault(u => u.ID == aspNetUser.UserId);
        //    //aspNetUser.UserAccount = userContent;

        //    if (aspNetUser.UserId == id)
        //    {
        //        var viewmodel = new UserFormEditViewModel(aspNetUser.UserAccount);
        //        return View(viewmodel);
        //    }
        //    return HttpNotFound();
        //}

        [Authorize]
        [HttpPost, ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        public ActionResult SaveEdit(UserFormEditViewModel viewmodel)
        {
            var userContent = context.GamersGridUsers
                .SingleOrDefault(u => u.ID == viewmodel.ID);
            userContent.Update(
                viewmodel.FirstName, viewmodel.LastName, viewmodel.NickName,
                viewmodel.Description, viewmodel.Country, viewmodel.Country);


            context.SaveChanges();

            return RedirectToAction("ProfilePage", new { nickname = userContent.NickName });
        }

        [Authorize]
        public ActionResult EditAvraam2()
        {
            var aspNetUserID = User.Identity.GetUserId();
            var ggtUser = context.Users.Where(u => u.Id == aspNetUserID)
                .Select(c => c.UserAccount)
                .SingleOrDefault();

            const int lolId = 1;
            const int dotaId = 2;
            const int overwatchId = 3;

            var userGameRelationLol = context.UserGameRelations
                .Where(ugr => ugr.GameID == lolId && ugr.UserId == ggtUser.ID)
                .Include(ugr=>ugr.GameAccount)
                .SingleOrDefault();

            var userGameRelationDota = context.UserGameRelations
               .Where(ugr => ugr.GameID == dotaId && ugr.UserId == ggtUser.ID)
               .Include(ugr => ugr.GameAccount)
               .SingleOrDefault();

            var userGameRelationOverwatch = context.UserGameRelations
               .Where(ugr => ugr.GameID == overwatchId && ugr.UserId == ggtUser.ID)
               .Include(ugr => ugr.GameAccount)
               .SingleOrDefault();


            //var userContent = context.GamersGridUsers.SingleOrDefault(u => u.ID == aspNetUser.UserId);
            //aspNetUser.UserAccount = userContent;

            var viewmodel = new UserFormEditViewModel(ggtUser, userGameRelationDota, userGameRelationLol, userGameRelationOverwatch);
            return View("EditAvraam2", viewmodel);

        }


        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(UserFormEditViewModel viewmodel, HttpPostedFileBase file)
        {
            var userContent = context.GamersGridUsers
                .SingleOrDefault(u => u.ID == viewmodel.ID);
            userContent.Update(
                viewmodel.FirstName, viewmodel.LastName, viewmodel.NickName,
                viewmodel.Description, viewmodel.Country, viewmodel.Country);

            if (!(file is null))
            {
                userContent.Update(ExtraMethods.UploadPhoto(userContent.ID, file));
            }

            context.SaveChanges();

            return RedirectToAction("ProfilePage", new { nickname = userContent.NickName });
        }
        //Get lolAccount
        public ActionResult LOLAccount()
        {
            int lolID = context.Games
                .Where(g => g.Title == "League Of Legends")
                .Select(g => g.ID)
                .SingleOrDefault();
            //check if the user is correct AspNetUser == User
            var appUserId = User.Identity.GetUserId();
            var userContent = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .Include(ug => ug.UserGames.Select(g => g.GameAccount))
                .SingleOrDefault();
            var userGame = userContent.UserGames.SingleOrDefault(g => g.Id == lolID);
            // instead of userGame != the check is done if a gameAcc exists or not
            if (userGame != null && userGame.GameAccount != null)
                return View(new AddLOLAccountViewmodel(userGame.GameAccount.NickName, userGame.GameAccount.AccountRegions));


            return View(new AddLOLAccountViewmodel());
        }
        ////Get OverWatch Account
        public ActionResult OverWatchAccount()
        {

            int overwatchID = context.Games
                .Where(g => g.Title == "Overwatch")
                .Select(g => g.ID)
                .SingleOrDefault();

            var appUserId = User.Identity.GetUserId();
            var userContent = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .Include(ug => ug.UserGames.Select(g => g.GameAccount))
                .SingleOrDefault();
            var userGame = context.UserGameRelations
                .SingleOrDefault(ug => ug.UserId == userContent.ID && ug.GameID == overwatchID);
            if (userGame != null)
                return View(new AddOverwatchAccViewModel(userGame.GameAccount.AccountIdentifier, userGame.GameAccount.AccountRegions));
            return View(new AddOverwatchAccViewModel());
        }

        // Dota 2 Account
        public ActionResult DotaAccount()
        {
            string userId = User.Identity.GetUserId();

            int ggUserAccountId = context.Users.Where(u => u.Id == userId)
                .Select(u => u.UserAccount.ID)
                .SingleOrDefault();

            var userGame = context.UserGameRelations
                .Include(ug => ug.GameAccount)
                .SingleOrDefault(ug => ug.UserId == ggUserAccountId && ug.GameID == 3);

            if (userGame == null)
                return View(new AddDotaAccountViewModel());

            return View(new AddDotaAccountViewModel(userGame.GameAccount.AccountIdentifier));
        }

        public ActionResult PostMessageEdit()
        {
            var appUserId = User.Identity.GetUserId();
            var otherUsers = context.Users
                .Where(u => u.Id != appUserId)
                .ToList();

            return View("PostMessage", new PostMessageViewModel(otherUsers));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostMessageSave(PostMessageViewModel viewModel)
        {
            var appUserId = User.Identity.GetUserId();
            var posterid = context.Users.Where(u => u.Id == appUserId).Select(u => u.UserId).Single();

            context.UserPostings.Add(new UserPosting(viewModel.PostingMessage, viewModel.OwnerId, posterid));
            context.SaveChanges();


            return RedirectToAction("ProfilePage");
        }

        public ViewResult Leaderboards()
        {

            return View();
        }
    }
}
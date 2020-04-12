﻿using AutoMapper;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Enums;
using GamersGridApp.Helpers;
using GamersGridApp.Models;
using GamersGridApp.Models.GameAccounts;
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
                Game = favoritegame
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



            return View(viewModel);
        }

        //Get
        [Authorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id)
        {
            var aspNetUserID = User.Identity.GetUserId();
            var aspNetUser = context.Users.Where(u => u.Id == aspNetUserID)
                .Include(c => c.UserAccount)
                .SingleOrDefault();
            //var userContent = context.GamersGridUsers.SingleOrDefault(u => u.ID == aspNetUser.UserId);
            //aspNetUser.UserAccount = userContent;

            if (aspNetUser.UserId == id)
            {
                var viewmodel = new UserFormEditViewModel(aspNetUser.UserAccount);
                return View(viewmodel);
            }
            return HttpNotFound();
        }

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
            var aspNetUser = context.Users.Where(u => u.Id == aspNetUserID)
                .Include(c => c.UserAccount)
                .SingleOrDefault();
            //var userContent = context.GamersGridUsers.SingleOrDefault(u => u.ID == aspNetUser.UserId);
            //aspNetUser.UserAccount = userContent;

            var viewmodel = new UserFormEditViewModel(aspNetUser.UserAccount);
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
        //public ActionResult LOLAccount()
        //{
        //    var appUserId = User.Identity.GetUserId();
        //    var lolAccount = context.Users
        //        .Where(u => u.Id == appUserId)
        //        .Select(u => u.UserAccount)
        //        .Select(u => u.ga)
        //        .SingleOrDefault();

        //    if (lolAccount != null)
        //        return View(new AddLOLAccountViewmodel(lolAccount.Name, lolAccount.Region));

        //    return View(new AddLOLAccountViewmodel());
        //}

        //Post lolAccount
        //[Authorize]
        //[HttpPost]
        //public ActionResult LOLAccount(AddLOLAccountViewmodel viewModel)
        //{
        //    //geting UserContent
        //    var appUserId = User.Identity.GetUserId();
        //    var userContent = context.Users
        //        .Where(u => u.Id == appUserId)
        //        .Select(u => u.UserAccount)
        //        .SingleOrDefault();
        //    //api is updated everyday
        //    string api = "RGAPI-dba8c12d-c214-4094-a0ac-aca9537f02e6";

        //    var url = String.Format("https://{0}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{1}?api_key={2}",
        //        viewModel.Region, viewModel.UserName, api);

        //    url = HttpUtility.UrlPathEncode(url);

        //    using (WebClient client = new WebClient())
        //    {
        //        // 1) BAD reuqest, handle here all 400 request from LOLServer
        //        //try { }
        //        //catch (WebException ex)
        //        //{ return HttpStatusCode.NotFound; }

        //        string json = client.DownloadString(url);

        //            LOLDto rootAccount = (new JavaScriptSerializer()).Deserialize<LOLDto>(json);


        //        LOLAccount lolAcount = Mapper.Map<LOLDto, LOLAccount>(rootAccount);

        //        lolAcount.AddToUser(userContent, userContent.ID, viewModel.Region);

        //        //Leave for now to check if the above method works normally
        //        //lolAcount.UserId = userContent.ID;
        //        //userContent.AccountLOL = lolAcount;
        //        //userContent.AccountLOL.Region = viewModel.Region;

        //        context.SaveChanges();
        //    }
        //    return RedirectToAction("ProfilePage", new { userid = userContent.ID });
        //}
    }
}
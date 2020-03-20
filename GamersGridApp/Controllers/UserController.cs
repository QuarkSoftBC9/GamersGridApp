using AutoMapper;
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
using System.Data.Entity;

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

        public ActionResult ProfilePage( int userid)
        {

            var user = context.GamersGridUsers.SingleOrDefault(u => u.ID == userid);


            if (user == null)
                return HttpNotFound();

            var loggedUserId = User.Identity.GetUserId();
            var currentLoggedUser = context.Users.Where(u => u.Id == loggedUserId).Select(u => u.UserAccount).SingleOrDefault();
            var viewModel = new UserProfilePageViewModel()
            {
                User = user
            };


            if (currentLoggedUser.ID == user.ID)
            {
                var follows = context.Follows.Count(f => f.UserId == currentLoggedUser.ID);
                viewModel.FollowsCount = follows;
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
                var viewmodel = new UserFormEditViewModel()
                {
                    ID = aspNetUser.UserAccount.ID,
                    FirstName = aspNetUser.UserAccount.FirstName,
                    LastName = aspNetUser.UserAccount.LastName,
                    NickName = aspNetUser.UserAccount.NickName,
                    City = aspNetUser.UserAccount.City,
                    Country = aspNetUser.UserAccount.Country,
                    Description = aspNetUser.UserAccount.Description
                };
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

        //Get api/lol
        public ActionResult LolApi()
        {
            //Should check if the user already has Acccount connected
            return View();
        }

        //Post api/lol
        [Authorize]
        [HttpPost]
        public ActionResult LolApi(LoLRegions region, string userName)
        {
            //geting UserContent
            var appUserId = User.Identity.GetUserId();
            var userContent = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .SingleOrDefault();


            //api is updated everyday
            string api = "RGAPI-0f438fad-b9b5-4402-8d2f-baebbdd4d424";

            var correctString = String.Format("https://{0}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{1}?api_key={2}",
                region, userName, api);

            correctString = HttpUtility.UrlPathEncode(correctString);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(correctString);

                //Converting to OBJECT from JSON string.
                LOLDto rootAccount = (new JavaScriptSerializer()).Deserialize<LOLDto>(json);

                AccountLOL lolAcount = Mapper.Map<LOLDto, AccountLOL>(rootAccount);

                lolAcount.UserId = userContent.ID;
                userContent.AccountLOL = lolAcount;
                context.SaveChanges();

            }
            return RedirectToAction("ProfilePage", new { nickname = userContent.NickName });
        }
    }
}
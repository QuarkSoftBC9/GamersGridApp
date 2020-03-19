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

        public ActionResult ProfilePage(string nickname)
        {
            
            var user = context.GamersGridUsers.SingleOrDefault(u => u.NickName.Contains(nickname));

            if (user == null)
                return HttpNotFound();

            return View(user);
        }

        //public ActionResult Register()
        //{
        //    var viewmodel = new UserRegisterViewModel();

        //    return View("UserFormRegister", viewmodel);
        //}

        //public ActionResult RegisterStrange()
        //{
        //    return View();
        //}

        public ActionResult Edit()
        {
            var viewmodel = new UserFormEditViewModel();

            return View("UserFormEdit", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveEdit(User user)
        {
            //Edit
            var userInDb = context.GamersGridUsers.Single(u => u.ID == user.ID);

            userInDb.FirstName = user.FirstName;
            userInDb.LastName = user.LastName;
            //userInDb.Email = user.Email;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SaveRegisterStrange(ViewModels.RegisterViewModel userViewModel, HttpPostedFileBase file)
        //{

        //    var fileName = ExtraMethods.UploadPhoto(file);
        //    userViewModel.Avatar = fileName;

        //    var newUser = new User()
        //    {
        //        FirstName = userViewModel.FirstName,
        //        LastName = userViewModel.LastName,
        //        //Street_Name = userViewModel.StreetName,
        //        //Street_Number = userViewModel.StreetNumber,
        //        Country = userViewModel.Country,
        //        City = userViewModel.City,
        //        Avatar = userViewModel.Avatar
        //       // Email = userViewModel.Email
        //    };
        //    //newUser.FavouriteGame.AddRange(userViewModel.FavouriteGames);
        //    context.GamersGridUsers.Add(newUser);

        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult SaveRegister(UserRegisterViewModel userViewModel)
        //{
        //    var newUser = new User()
        //    {
        //        FirstName = userViewModel.FirstName,
        //        LastName = userViewModel.LastName,
        //        //Email = userViewModel.Email

        //    };
        //    context.GamersGridUsers.Add(newUser);

        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
            
            var correctString =  String.Format("https://{0}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{1}?api_key={2}",
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
            return RedirectToAction("ProfilePage", new { nickname = userContent.NickName});
        }
    }
}
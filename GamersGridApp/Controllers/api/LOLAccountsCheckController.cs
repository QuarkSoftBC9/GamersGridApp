using GamersGridApp.Enums;
using GamersGridApp.Models;
using GamersGridApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web;
using System.Web.Mvc;


namespace GamersGridApp.Controllers.api
{
    [System.Web.Http.Authorize]
    public class LOLAccountsCheckController : ApiController
    {
        private readonly ApplicationDbContext context;

        public LOLAccountsCheckController()
        {
            context = new ApplicationDbContext();
            // context = new MyDbContext();
            // Uncomment for costum DbContext
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }



        //[System.Web.Http.HttpPost]
        public IHttpActionResult CheckAccount(AddLOLAccountViewmodel user)
        {
            if (String.IsNullOrEmpty(user.UserName) || user.Region == 0)
                return BadRequest("they are null");
            var accountExists = context.GameAccounts 
                .Where(la => la.NickName == user.UserName && la.AccountRegions == user.Region)
                .SingleOrDefault();
            if (accountExists != null)
                return BadRequest("The account already exists");
            else
                return Ok("Ok");

        }
    }
}

using AutoMapper;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Models;
using GamersGridApp.Models.GameAccounts;
using GamersGridApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace GamersGridApp.Controllers.api
{
    [Authorize]
    public class LOLAccountsController : ApiController
    {
        private readonly ApplicationDbContext context;

        public LOLAccountsController()
        {
            context = new ApplicationDbContext();
            // context = new MyDbContext();
            // Uncomment for costum DbContext
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        //[HttpPost]
        //public IHttpActionResult AddAccount(AddLOLAccountViewmodel viewModel)
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

        //        LOLDto rootAccount = (new JavaScriptSerializer()).Deserialize<LOLDto>(json);

        //        LOLAccount lolAcount = Mapper.Map<LOLDto, LOLAccount>(rootAccount);

        //        lolAcount.AddToUser(userContent, userContent.ID, viewModel.Region);

        //        context.SaveChanges();

        //        return Ok();
        //    }

        //}
    }
}

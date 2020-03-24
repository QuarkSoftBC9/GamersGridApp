using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using AutoMapper;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Dtos.ApiStatsDto;
using GamersGridApp.Models;
using GamersGridApp.Models.GameAccounts;
using Microsoft.AspNet.Identity;

namespace GamersGridApp.Controllers.api
{
    [Authorize]
    public class LOLStatsController : ApiController
    {
        private readonly ApplicationDbContext context;

        public LOLStatsController()
        {
            context = new ApplicationDbContext();
            // context = new MyDbContext();
            // Uncomment for costum DbContext
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        //public LOLStatsDto GetLoLStats()
        //{
        //    var userId = User.Identity.GetUserId();
        //    LOLStatsDto rootData;

        //    var user = context.Users
        //        .Where(u => u.Id == userId)
        //        .Select(u => u.UserAccount)
        //        .Select(la => la.)
        //        .SingleOrDefault();

        //    string api = "RGAPI-0f438fad-b9b5-4402-8d2f-baebbdd4d424";
        
        //    var url = String.Format("https://{0}.api.riotgames.com/lol/summoner/v4/summoners/{1}?api_key={2}",
        //        user.Region, user.Id, api);
        //    url = HttpUtility.UrlPathEncode(url); //check if the using is correct
            
        //    using (WebClient client = new WebClient())
        //    {
        //        string json = client.DownloadString(url);

        //        //Converting to OBJECT from JSON string.
        //         rootData = (new JavaScriptSerializer()).Deserialize<LOLStatsDto>(json);

        //        // senario 1 : use existing LOLAccount to check if it gets updated or some data is overriden
        //        LOLAccount lolAcount = Mapper.Map<LOLStatsDto, LOLAccount>(rootData);

        //        context.SaveChanges();
        //    }

        //    return rootData;
        //}
    }
}

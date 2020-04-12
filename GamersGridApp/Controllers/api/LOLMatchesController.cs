using AutoMapper.QueryableExtensions;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Models;
using GamersGridApp.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace GamersGridApp.Controllers.api
{
    public class LOLMatchesController : ApiController
    {
        private readonly ApplicationDbContext context;

        public LOLMatchesController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        [HttpGet] // major refactoring needed
        public List<LOLMatchesDto> GetStats()
        {
            var appUserId = User.Identity.GetUserId();
            var userContent = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .Include(g => g.UserGames.Select(ga => ga.GameAccount).Select(s => s.GameAccountStats))
                .SingleOrDefault();
            if (userContent == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            var gameAccount = userContent.UserGames.SingleOrDefault(g => g.GameID == 1).GameAccount;
            if (String.IsNullOrEmpty(gameAccount.AccountIdentifier))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //api is updated everyday
            string api = "RGAPI-98d1f24c-1e8e-47d5-91e6-859ec304cf36";

            var urlMatches = String.Format("https://eun1.api.riotgames.com/lol/match/v4/matchlists/by-account/{0}?endIndex=10&beginIndex=0&api_key={1}",
                gameAccount.AccountIdentifier2, api);

            urlMatches = HttpUtility.UrlPathEncode(urlMatches);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(urlMatches);

                var rootAccounts = (new JavaScriptSerializer()).Deserialize<LOLMatchesListDto>(json);

                //add if for a null rank
                var matches = new List<LOLMatchesDto>() { };
                foreach (var match in rootAccounts.matches)
                {
                    var url = String.Format("https://eun1.api.riotgames.com/lol/match/v4/matches/{0}?api_key={1}", match.gameId, api);
                    string jsonMatch = client.DownloadString(url);
                    var rootAccountsMatch = (new JavaScriptSerializer()).Deserialize<LOLMatchesDto>(jsonMatch);
                    matches.Add(rootAccountsMatch);
                }

                if (gameAccount.GameAccountStats == null)
                    return null;
                else
                    gameAccount.GameAccountStats.UpdateKDA(matches, gameAccount.AccountIdentifier2);

                context.SaveChanges();
                return matches;

            }

        }

    }
    
}

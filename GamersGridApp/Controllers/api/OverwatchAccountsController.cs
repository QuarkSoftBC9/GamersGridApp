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
    public class OverwatchAccountsController : ApiController
    {
        private readonly ApplicationDbContext context;

        public OverwatchAccountsController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        [HttpPost]
        public IHttpActionResult AddAccount(AddOverwatchAccViewModel viewModel)
        {
            if (String.IsNullOrEmpty(viewModel.UserName))
                return BadRequest("Name is not set");
            // OverWatchID
            int overwatchID = context.Games
                .Where(g => g.Title == "Overwatch")
                .Select(g => g.ID)
                .SingleOrDefault();

            //geting UserContent
            var appUserId = User.Identity.GetUserId();
            var userContent = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .Include(g => g.UserGames.Select(ga => ga.GameAccount))
                .SingleOrDefault();
            if (userContent == null)
                return BadRequest("User could not be found");

            var userGame = userContent.UserGames.SingleOrDefault(g => g.GameID == overwatchID);

            //api no key required
            string userName = viewModel.GetBattleTag();
            var url = String.Format("https://ow-api.com/v1/stats/pc/{0}/{1}/profile",
                viewModel.Region, userName);

            url = HttpUtility.UrlPathEncode(url);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OverWatchDto rootAccount = (new JavaScriptSerializer()).Deserialize<OverWatchDto>(json);

                if (userGame == null)
                {
                    GameAccount newAccount = new GameAccount(viewModel.UserName, userName, viewModel.Region) { };
                    newAccount.GameAccountStats = new GameAccountStats(newAccount, rootAccount.rating.ToString(),
                        rootAccount.competitiveStats.games.won, 
                        (rootAccount.competitiveStats.games.played - rootAccount.competitiveStats.games.won));
                    userContent.UserGames.Add(new UserGame(overwatchID, userContent.ID, newAccount));
                }
                else
                    userGame.GameAccount.UpdateLOLAccount(viewModel.UserName, userName, viewModel.Region);

                context.SaveChanges();
                return Ok("All good");
            }

        }
        //get overwatch stats
        //[HttpGet]
        //public List<LOLStatsDto> GetStats()
        //{
        //    var appUserId = User.Identity.GetUserId();
        //    var userContent = context.Users
        //        .Where(u => u.Id == appUserId)
        //        .Select(u => u.UserAccount)
        //        .Include(g => g.UserGames.Select(ga => ga.GameAccount).Select(s => s.GameAccountStats))
        //        .SingleOrDefault();
        //    if (userContent == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    var gameAccount = userContent.UserGames.SingleOrDefault(g => g.GameID == 1).GameAccount;
        //    if (String.IsNullOrEmpty(gameAccount.AccountIdentifier))
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    //api is updated everyday
        //    string api = "RGAPI-3d73158b-d7bc-472e-8905-2105c5062a00";

        //    var url = String.Format("https://{0}.api.riotgames.com/lol/league/v4/entries/by-summoner/{1}?api_key={2}",
        //        gameAccount.AccountRegions, gameAccount.AccountIdentifier, api);

        //    url = HttpUtility.UrlPathEncode(url);

        //    using (WebClient client = new WebClient())
        //    {
        //        string json = client.DownloadString(url);

        //        var rootAccounts = (new JavaScriptSerializer()).Deserialize<List<LOLStatsDto>>(json);
        //        Console.WriteLine("hi there");
        //        string tier = rootAccounts[0].tier + " " + rootAccounts[0].rank;
        //        if (gameAccount.GameAccountStats == null)
        //        {
        //            var accountStats = new GameAccountStats(gameAccount, tier, rootAccounts[0].wins);
        //            context.GameAccountStats.Add(accountStats);
        //        }
        //        else
        //            gameAccount.GameAccountStats.UpdateStats(tier, rootAccounts[0].wins);

        //        context.SaveChanges();
        //        return rootAccounts;

        //    }

        //}
    }
}

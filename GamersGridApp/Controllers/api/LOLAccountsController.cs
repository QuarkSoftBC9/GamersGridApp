using AutoMapper;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Dtos.GameStats;
using GamersGridApp.Models;
using GamersGridApp.ViewModels;
using GamersGridApp.WebServices;
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
    [System.Web.Http.Authorize]
    public class LOLAccountsController : ApiController
    {
        private readonly string api = "RGAPI-21acf2b4-fd34-43ae-9461-a694cd0a6d22";
        private readonly int lolID = 1;
        private readonly ApplicationDbContext context;

        public LOLAccountsController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        [HttpPost]
        public LOLDto AddAccount(AddLOLAccountViewmodel viewModel)
        {
            //Check if data was returned correctly
            if ((String.IsNullOrEmpty(viewModel.UserName)) || (String.IsNullOrEmpty(viewModel.Region)))
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Get the logged in  User 
            var appUserId = User.Identity.GetUserId();
            var userContent = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .Include(g => g.UserGames.Select(ga => ga.GameAccount))
                .SingleOrDefault();

            //Check if userContent exists
            if (userContent == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            //Download LOL Account 
            string urlAccount = String.Format("https://{0}.api.riotgames.com/lol/summoner/v4/summoners/by-name/{1}?api_key={2}",
                viewModel.Region, viewModel.UserName, api);
            urlAccount = HttpUtility.UrlPathEncode(urlAccount);
            LOLDto accDto = new LOLDto();
            try
            {
                accDto = DataService.GetAccount(urlAccount);
            }
            catch (WebException ex)
            {
                throw new WebException(ex.ToString());
            }
            //New Game Account
            var userGame = userContent.NewUserGame(lolID);
            userGame.NewGameAccount(viewModel.UserName, accDto.id, accDto.accountId, viewModel.Region);
            context.SaveChanges();
            //Download LOL Stats
            var urlStats = String.Format("https://{0}.api.riotgames.com/lol/league/v4/entries/by-summoner/{1}?api_key={2}",
                userGame.GameAccount.AccountRegions, userGame.GameAccount.AccountIdentifier, api);
            urlStats = HttpUtility.UrlPathEncode(urlStats);
            var statsDto = DataService.GetStats(urlStats);

            //Update or create Stats
            userGame.GameAccount.GameAccountStats = context.GameAccountStats.Where(gs => gs.Id == userGame.Id).SingleOrDefault();
            userGame.GameAccount.UpdateStats(statsDto[0].tier + " " + statsDto[0].rank, statsDto[0].wins, statsDto[0].losses);

            context.SaveChanges();
            return accDto;

        }
        [HttpGet]
        public List<LOLMatchesDto> GetStats()
        {
            //getting user
            var appUserId = User.Identity.GetUserId();
            var gameAccount = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .Select(g => g.UserGames.Where(ug => ug.GameID == lolID).Select(ga => ga.GameAccount).FirstOrDefault())
                .Include(gs => gs.GameAccountStats)
                .SingleOrDefault();
            if (gameAccount == null || gameAccount.GameAccountStats == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Getting List of matche ids
            var urlMatches = String.Format("https://eun1.api.riotgames.com/lol/match/v4/matchlists/by-account/{0}?endIndex=10&beginIndex=0&api_key={1}",
                gameAccount.AccountIdentifier2, api);
            urlMatches = HttpUtility.UrlPathEncode(urlMatches);
            var matchIds = DataService.GetMatcheList(urlMatches);
            var gameIds = matchIds.matches.Select(g => g.gameId);

            //getting the list of matches
            var matches = DataService.GetMatches(api, gameIds);
            var kda = gameAccount.GameAccountStats.UpdateKDA(matches, gameAccount.AccountIdentifier2);
            gameAccount.GameAccountStats.KDA = kda;

            context.SaveChanges();
            return matches;
        }
    }
}

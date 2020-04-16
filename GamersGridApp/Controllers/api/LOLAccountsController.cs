using AutoMapper;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Dtos.ApiStatsDto;
using GamersGridApp.Models;
using GamersGridApp.Repositories;
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
        private readonly string api = "RGAPI-89701b27-a5b5-4404-8f33-d1ca1015645e";
        private readonly int lolID = 1;
        private readonly ApplicationDbContext context;
        private readonly GameAccountStatsRepository accountStats;

        public LOLAccountsController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        [HttpPost]
        public LOLStatsDto AddAccount(AddLOLAccountViewmodel viewModel)
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
            LOLDto accDto = new LOLDto();
            accDto = LolDataService.GetAccount(viewModel.Region, viewModel.UserName, api);
            
            //New Game Account
            var userGame = userContent.NewUserGame(lolID);
            userGame.NewGameAccount(viewModel.UserName, accDto.id, accDto.accountId, viewModel.Region);

            //Download LOL Stats
            List<LOLStatsDto> statsDto = new List<LOLStatsDto>();
            statsDto = LolDataService.GetStats(userGame.GameAccount.AccountRegions, userGame.GameAccount.AccountIdentifier, api);

            //Update or create Stats
            userGame.GameAccount.GameAccountStats = accountStats.GetGameAccStatsByID(userGame.Id);
            userGame.GameAccount.UpdateStats(statsDto[0].tier + " " + statsDto[0].rank, statsDto[0].wins, statsDto[0].losses);

            context.SaveChanges();
            return statsDto[0];

        }
        //[HttpGet]
        //public List<LOLMatchesDto> GetStats()
        //{
        //    //getting user
        //    var appUserId = User.Identity.GetUserId();
        //    var gameAccount = context.Users
        //        .Where(u => u.Id == appUserId)
        //        .Select(u => u.UserAccount)
        //        .Select(g => g.UserGames.Where(ug => ug.GameID == lolID).Select(ga => ga.GameAccount).FirstOrDefault())
        //        .Include(gs => gs.GameAccountStats)
        //        .SingleOrDefault();
        //    if (gameAccount == null || gameAccount.GameAccountStats == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);
        //    //Getting List of matche ids
        //    var matchIds = LolDataService.GetMatcheList(gameAccount.AccountIdentifier2, api);
        //    var gameIds = matchIds.matches.Select(g => g.gameId);

        //    //getting the list of matches
        //    var matches = LolDataService.GetMatches(api, gameIds);
        //    gameAccount.GameAccountStats.UpdateKDA(matches, gameAccount.AccountIdentifier2);

        //    context.SaveChanges();
        //    return matches;
        //}
    }
}

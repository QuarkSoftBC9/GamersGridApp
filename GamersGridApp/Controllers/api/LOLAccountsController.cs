using AutoMapper;
using GamersGridApp.Core;
using GamersGridApp.Core.ApiAcountsDtos;
using GamersGridApp.Core.Dtos.ApiStatsDto;
using GamersGridApp.Core.ViewModels;
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
        private readonly string api = "RGAPI-4100f21e-cce1-4513-802c-c5f916f7ed4c";
        private readonly int lolID = 1;

        private readonly IUnitOfWork UnitOfWork;


        public LOLAccountsController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        [HttpPost]
        public IHttpActionResult AddAccount(AddLOLAccountViewmodel viewModel)
        {
            LOLDto accDto = new LOLDto();
            List<LOLStatsDto> statsDto = new List<LOLStatsDto>();

            //Check if data was returned correctly
            if ((String.IsNullOrEmpty(viewModel.UserName)) || (String.IsNullOrEmpty(viewModel.Region)))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            //Get the logged in  User 
            var appUserId = User.Identity.GetUserId();
            var userContent = UnitOfWork.GGUsers.GetUserContent(appUserId);

            //Check if userContent exists
            if (userContent == null)
                return BadRequest("No such account was found");

            //Check if Game Account with such credential alrady exists
            var accountExists = UnitOfWork.GameAccounts.GetGameAccByNameAndRegion(viewModel.UserName, viewModel.Region);
            if (accountExists != null && accountExists.Id != (userContent.UserGames.SingleOrDefault(g => g.GameID == lolID)).Id)
                return BadRequest("The account already exists");

            //Download LOL Account 
            accDto = LolDataService.GetAccount(viewModel.Region, viewModel.UserName, api);
            
            //New Game Account
            var userGame = userContent.NewUserGame(lolID);
            userGame.NewGameAccount(viewModel.UserName, accDto.id, accDto.accountId, viewModel.Region);

            //Download LOL Stats
            statsDto = LolDataService.GetStats(userGame.GameAccount.AccountRegions, userGame.GameAccount.AccountIdentifier, api);

            //Update or create Stats
            if(statsDto != null)
            {
                userGame.GameAccount.GameAccountStats = UnitOfWork.GameAccountStats.GetGameAccStatsByID(userGame.Id);
                userGame.GameAccount.UpdateStats(statsDto[0].tier + " " + statsDto[0].rank, statsDto[0].wins, statsDto[0].losses);//break here check

                //Getting List of matche ids
                var matchIds = LolDataService.GetMatcheList(userGame.GameAccount.AccountIdentifier2, api);
                var gameIds = matchIds.matches.Select(g => g.gameId);

                //getting the list of matches
                var matches = LolDataService.GetMatches(api, gameIds);
                userGame.GameAccount.GameAccountStats.UpdateKDA(matches, userGame.GameAccount.AccountIdentifier2);
            }
            UnitOfWork.Complete();
            return Ok(statsDto[0]);

        }
        [HttpGet]
        public FullStatsDto GetStats(string region, string name)
        {
            //get account
            FullStatsDto fullStatsDto = new FullStatsDto();
            fullStatsDto.Account = LolDataService.GetAccount(region, name, api);

            //get stats
            fullStatsDto.Stats = LolDataService.GetStats(region, fullStatsDto.Account.id, api).Single();

            //get latest match
            //if(fullStatsDto.Stats != null)
            //{
            //    var matchIds = LolDataService.GetMatcheList(fullStatsDto.Account.accountId, api, 0, 1);
            //    var gameIds = matchIds.matches.Select(g => g.gameId);
            //    var matches = LolDataService.GetMatches(api, gameIds);
            //    var playerMatchID = matches[0].participantIdentities
            //        .Where(p => p.player.accountId == fullStatsDto.Account.accountId)
            //        .Select(pid => pid.participantId)
            //        .SingleOrDefault();

            //    var playerMatchStats = matches[0].participants.SingleOrDefault(ps => ps.participantId == playerMatchID);
            //    fullStatsDto.SummonerStats = playerMatchStats;
            //}
            return fullStatsDto;
        }

    }
}

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
using GamersGridApp.Dtos.ApiStatsDto;
using GamersGridApp.WebServices;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Repositories;
using GamersGridApp.WebServices;

namespace GamersGridApp.Controllers.api
{
    [Authorize]
    public class LOLAccountsCheckController : ApiController
    {
        private readonly ApplicationDbContext context;
        private readonly GameAccountRepository gameAccounts;
        private readonly string api = "RGAPI-e06e9739-e073-454b-a242-5a35b1c38a02";

        public LOLAccountsCheckController()
        {
            context = new ApplicationDbContext();
            gameAccounts = new GameAccountRepository(context);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        //[System.Web.Http.HttpPost]
        public IHttpActionResult CheckAccount(AddLOLAccountViewmodel user)
        {
            //cuur ID
            if (String.IsNullOrEmpty(user.UserName) || String.IsNullOrEmpty(user.Region))
                return BadRequest("they are null");
            var accountExists = gameAccounts.GetGameAccByNameAndRegion(user.UserName, user.Region);

            if (accountExists != null)
                return BadRequest("The account already exists");
            else
                return Ok("Ok");

        }
        //Add here Get Stats Method
        public FullStatsDto GetStats(AddLOLAccountViewmodel viewModel)
        {
            //get account
            FullStatsDto fullStatsDto = new FullStatsDto();
            fullStatsDto.Account = LolDataService.GetAccount(viewModel.Region, viewModel.UserName, api);

            //get stats
            fullStatsDto.Stats = LolDataService.GetStats(viewModel.Region, fullStatsDto.Account.puuid, api).Single();

            //get latest match
            var matchIds = LolDataService.GetMatcheList(fullStatsDto.Account.accountId, api, 0, 1);
            var gameIds = matchIds.matches.Select(g => g.gameId);
            var matches = LolDataService.GetMatches(api, gameIds);
            fullStatsDto.SingleMatch = matches[0];

            return fullStatsDto;
        }
    }
}

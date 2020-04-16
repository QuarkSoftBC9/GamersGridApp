﻿using GamersGridApp.Enums;
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

namespace GamersGridApp.Controllers.api
{
    [Authorize]
    public class LOLAccountsCheckController : ApiController
    {
        private readonly ApplicationDbContext context;
        private readonly string api = "RGAPI-89701b27-a5b5-4404-8f33-d1ca1015645e";

        public LOLAccountsCheckController()
        {
            context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        //[System.Web.Http.HttpPost]
        public IHttpActionResult CheckAccount(AddLOLAccountViewmodel user)
        {
            if (String.IsNullOrEmpty(user.UserName) || String.IsNullOrEmpty(user.Region))
                return BadRequest("they are null");
            var accountExists = context.GameAccounts
                .Where(la => la.NickName == user.UserName && la.AccountRegions == user.Region)
                .SingleOrDefault();
            if (accountExists != null)
                return BadRequest("The account already exists");
            else
                return Ok("Ok");

        }
        //Add here Get Stats Method
        public FullStatsDto GetStats(AddLOLAccountViewmodel viewModel)
        {
            FullStatsDto fullStatsDto = new FullStatsDto();
            fullStatsDto.Account = LolDataService.GetAccount(viewModel.Region, viewModel.UserName, api);

            fullStatsDto.Stats = LolDataService.GetStats(viewModel.Region, fullStatsDto.Account.puuid, api).Single();

            var matchIds = LolDataService.GetMatcheList(fullStatsDto.Account.accountId, api, 0, 1);
            var gameIds = matchIds.matches.Select(g => g.gameId);
            var matches = LolDataService.GetMatches(api, gameIds);
            fullStatsDto.SingleMatch = matches[0];
            return fullStatsDto;
        }
    }
}

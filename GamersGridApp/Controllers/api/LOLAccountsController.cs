using AutoMapper;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Dtos.ApiStatsDto;
using GamersGridApp.Models;
using GamersGridApp.Perstistence;
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
        private readonly string api = "RGAPI-d466cf9c-9f85-49a9-9d79-b02bd9fdd884";
        private readonly int lolID = 1;
        private readonly ApplicationDbContext context;
        private readonly IGameAccountStatsRepository gameAccountStats;
        private readonly IGameAccountRepository gameAccounts;
        private readonly IUserGameRepository userGameRelationsRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;


        public LOLAccountsController()
        {
            context = new ApplicationDbContext();
            gameAccounts = new GameAccountRepository(context);
            gameAccountStats = new GameAccountStatsRepository(context);
            userGameRelationsRepository = new UserGameRepository(context);
            userRepository = new UserRepository(context);
            unitOfWork = new UnitOfWork(context);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        [HttpPost]
        public IHttpActionResult AddAccount(AddLOLAccountViewmodel viewModel)
        {
            //Check if data was returned correctly
            if ((String.IsNullOrEmpty(viewModel.UserName)) || (String.IsNullOrEmpty(viewModel.Region)))
                throw new HttpResponseException(HttpStatusCode.NotFound);
            
            //Get the logged in  User 
            var appUserId = User.Identity.GetUserId();
            //var userContent = context.Users
            //    .Where(u => u.Id == appUserId)
            //    .Select(u => u.UserAccount)
            //    .Include(g => g.UserGames.Select(ga => ga.GameAccount))
            //    .SingleOrDefault();
            var userContent = userRepository.GetUserContent(appUserId);

            //Check if userContent exists
            if (userContent == null)
                return BadRequest("No such account was found");

            //Check if Game Account with such credential alrady exists
            var accountExists = gameAccounts.GetGameAccByNameAndRegion(viewModel.UserName, viewModel.Region);
            if (accountExists != null && accountExists.Id != userContent.ID)
                return BadRequest("The account already exists");

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
            userGame.GameAccount.GameAccountStats = gameAccountStats.GetGameAccStatsByID(userGame.Id);
            userGame.GameAccount.UpdateStats(statsDto[0].tier + " " + statsDto[0].rank, statsDto[0].wins, statsDto[0].losses);

            //Getting List of matche ids
            var matchIds = LolDataService.GetMatcheList(userGame.GameAccount.AccountIdentifier2, api);
            var gameIds = matchIds.matches.Select(g => g.gameId);

            //getting the list of matches
            var matches = LolDataService.GetMatches(api, gameIds);
            userGame.GameAccount.GameAccountStats.UpdateKDA(matches, userGame.GameAccount.AccountIdentifier2);

            unitOfWork.Complete();
            return Ok(statsDto[0]);

        }

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

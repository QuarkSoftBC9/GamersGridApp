using GamersGrid.BLL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Models.Dtos;
using GamersGrid.Models.User;
using GamersGrid.Services.GameAPIs.LeagueOfLegends;
using GamersGrid.Services.GameAPIs.Overwatch;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoLAccountsController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LoLAccountsController> _logger;
        private readonly UserManager<GGuser> _userManager;
        private readonly LoLService lolApi;

        // LoLId
        private const int leagueId = 2;

        public LoLAccountsController(IUnitOfWork unitOfWork, ILogger<LoLAccountsController> logger, UserManager<GGuser> userManager, LoLService loLService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            lolApi = loLService;
        }

        [HttpGet]
        public async Task<IActionResult>  GetStats(string region, string name)
        {

            try
            {
                //get account
                LoLSearchDTO searchDTO = new LoLSearchDTO();
                var accDTO = await lolApi.GetAccount(region, name);

                //get stats
                var statsDTO = await lolApi.GetStats(region, accDTO.id);

                if (statsDTO.Count == 0)
                    return NotFound("Could not fetch data. Account seems inactive.");

                searchDTO.accountName = accDTO.name;
                searchDTO.rank = statsDTO[0].tier + " " + statsDTO[0].rank;
                searchDTO.summonerLevel = accDTO.summonerLevel.ToString();
                searchDTO.wins = statsDTO[0].wins.ToString();
                searchDTO.losses = statsDTO[0].losses.ToString();
                searchDTO.rankImagePath = $"/Static/Images/Games/LoLIcons/" + statsDTO[0].tier.ToLower() + "_" + statsDTO[0].rank.ToLower() + ".png";


                return Ok(searchDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAccount([FromForm] AddLoLAccountVM viewModel)
        {
            //Check if data was returned correctly
            if ((String.IsNullOrEmpty(viewModel.UserName)) || (String.IsNullOrEmpty(viewModel.Region)))
                return BadRequest();

            //Get the logged in  User 
            var user = await _userManager.GetUserAsync(User);

            try
            {
                //download stuff
                var loLDTO = await lolApi.GetAccount(viewModel.Region, viewModel.UserName);
                var LoLStatsDTO = await lolApi.GetStats(viewModel.Region, loLDTO.id);

                var matchIds = await lolApi.GetMatcheList(loLDTO.accountId);
                var gameIds = matchIds.matches.Select(g => g.gameId);
                var matches = await lolApi.GetMatches(gameIds);
                string KDA = lolApi.CalculateKDA(matches, loLDTO.accountId);


                //get account from db
                user.GameAccounts = (ICollection<GameAccount>)await _unitOfWork.GameAccounts.GetAll(gameAccount => gameAccount.UserId == user.Id, includeProperties: "Statistics");

                var lolAccount = user.GameAccounts.FirstOrDefault(gameAccount => gameAccount.GameId == leagueId);


                if (lolAccount == null)
                {
                    lolAccount = new GameAccount(viewModel.UserName, loLDTO.id, loLDTO.accountId, viewModel.Region);
                    lolAccount.UserId = user.Id;
                    lolAccount.GameId = leagueId;

                    lolAccount.Statistics = new GameAccountStats();
                    if (LoLStatsDTO.Count != 0)
                        lolAccount.Statistics.UpdateStats(LoLStatsDTO[0].tier + " " + LoLStatsDTO[0].rank, LoLStatsDTO[0].wins, LoLStatsDTO[0].losses, KDA);
                    user.GameAccounts.Add(lolAccount);
                }
                else
                {
                    lolAccount.UpdateAccount(viewModel.UserName, loLDTO.id, loLDTO.accountId, viewModel.Region);
                    if (LoLStatsDTO.Count != 0)
                        lolAccount.Statistics.UpdateStats(LoLStatsDTO[0].tier + " " + LoLStatsDTO[0].rank, LoLStatsDTO[0].wins, LoLStatsDTO[0].losses, KDA);
                }

                await _unitOfWork.Save();



                return Ok();



            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}

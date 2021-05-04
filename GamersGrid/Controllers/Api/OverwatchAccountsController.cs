using GamersGrid.BLL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Models.User;
using GamersGrid.Services.GameAPIs;
using GamersGrid.Services.GameAPIs.Overwatch;
using GamersGrid.Services.GameAPIs.Overwatch.Models;
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
    public class OverwatchAccountsController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OverwatchAccountsController> _logger;
        private readonly UserManager<GGuser> _userManager;
        private readonly OverwatchService overwatchAPI;
        // OverWatchID
        private const int overwatchId = 3;

        public OverwatchAccountsController(IUnitOfWork unitOfWork, ILogger<OverwatchAccountsController> logger, UserManager<GGuser> userManager,OverwatchService overwatchService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            overwatchAPI = overwatchService;
        }


        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return Ok();
        }

        [HttpPost]
        [Authorize]
        public async  Task<IActionResult> AddAccount([FromForm]AddOverwatchAccountVM viewModel)
        {
            if (String.IsNullOrEmpty(viewModel.BattleTag))
                return BadRequest("Name is not set");

            //Get user
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return BadRequest();

            StatisticsResult overwatchStatisticsResult; 

            try
            {
                overwatchStatisticsResult = await overwatchAPI.GetCompleteProfileDto(viewModel.BattleTag, viewModel.Region);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            user.GameAccounts = (ICollection<GameAccount>)await _unitOfWork.GameAccounts.GetAll(gameAccount => gameAccount.UserId == user.Id, includeProperties: "Statistics");

            var overwatchAccount = user.GameAccounts.FirstOrDefault(gameAccount=> gameAccount.GameId == overwatchId);

            if(overwatchAccount == null)
            {
                overwatchAccount = new GameAccount(overwatchStatisticsResult.NickName, viewModel.BattleTag, viewModel.Region);
                overwatchAccount.UserId = user.Id;
                overwatchAccount.GameId = overwatchId;

                overwatchAccount.Statistics = new GameAccountStats();
                overwatchAccount.Statistics.UpdateStats(overwatchStatisticsResult.Rank, overwatchStatisticsResult.Wins, overwatchStatisticsResult.Losses, overwatchStatisticsResult.KDA);
                user.GameAccounts.Add(overwatchAccount);
            }
            else
            {
                overwatchAccount.UpdateAccount(overwatchStatisticsResult.NickName, viewModel.BattleTag, viewModel.Region);
                overwatchAccount.Statistics.UpdateStats(overwatchStatisticsResult.Rank, overwatchStatisticsResult.Wins, overwatchStatisticsResult.Losses, overwatchStatisticsResult.KDA);
            }

            try
            {
                await _unitOfWork.Save();
            }
            catch(Exception ex)
            {

            }


            return Ok();

        }
    }
}

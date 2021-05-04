using GamersGrid.BLL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Services.GameAPIs.Dota;
using GamersGrid.Services.GameAPIs.Dota.Models;
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
    public class DotaAccountsController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DotaAccountsController> _logger;
        private readonly UserManager<GGuser> _userManager;
        private readonly DotaService dotaApi;

        // LoLId
        private const int dotaId = 1;

        public DotaAccountsController(IUnitOfWork unitOfWork, ILogger<DotaAccountsController> logger, UserManager<GGuser> userManager, DotaService dotaService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            dotaApi = dotaService;
        }



        [HttpPost]
        [Authorize]
        public async  Task<IActionResult> AddDotaAccount(string accountid)
        {
            if (string.IsNullOrEmpty(accountid))
                return BadRequest();


            string steamId = dotaApi.ConvertCommunityIdToSteamID(accountid);
            DotaDTO dotaDto;
            DotaWinsLosesDTO dotaWLDto;
            List<DotaMatchDTO> dotaMatchesDto;
            string kda;
            try
            {
                dotaDto = await dotaApi.GetAccountDto(steamId);
                dotaWLDto = await dotaApi.GetWLDto(steamId);
                dotaMatchesDto = await dotaApi.GetMatches(steamId);
                kda = dotaApi.CalculateKda(dotaMatchesDto).ToString();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            var user = await _userManager.GetUserAsync(User);

            user.GameAccounts = (ICollection<GameAccount>)await _unitOfWork.GameAccounts.GetAll(gameAccount => gameAccount.UserId == user.Id, includeProperties: "Statistics");

            var dotaAccount = user.GameAccounts.FirstOrDefault(gameAccount => gameAccount.GameId == dotaId);

            if (dotaAccount == null)
            {
                dotaAccount = new GameAccount(dotaDto.profile.steamid, accountid, dotaDto.profile.personaname, dotaDto.profile.loccountrycode);
                dotaAccount.UserId = user.Id;
                dotaAccount.GameId = dotaId;

                dotaAccount.Statistics = new GameAccountStats();
                dotaAccount.Statistics.UpdateStats(dotaDto.competitive_rank, dotaWLDto.win, dotaWLDto.lose, kda);
                user.GameAccounts.Add(dotaAccount);
            }
            else
            {
                dotaAccount.UpdateAccountDota(dotaDto.profile.steamid,dotaDto.profile.account_id.ToString(),dotaDto.profile.personaname,dotaDto.profile.loccountrycode);
                dotaAccount.Statistics.UpdateStats(dotaDto.competitive_rank,dotaWLDto.win,dotaWLDto.lose,kda);
            }

            await _unitOfWork.Save();


            return Ok();



        }

    }
}

using GamersGridApp.Dtos;
using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Helpers;
using GamersGridApp.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using System.Data.Entity;
using GamersGridApp.WebServices;
using GamersGridApp.Repositories;
using GamersGridApp.Perstistence;

namespace GamersGridApp.Controllers.api
{
    public class DotaAccountsController : ApiController
    {
        private ApplicationDbContext context;
        private readonly IGameRepository gameRepository;
        private readonly IUserGameRepository userGameRelationsRepository;
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;



        public DotaAccountsController()
        {
            context = new ApplicationDbContext();
            gameRepository = new GameRepository(context);
            userGameRelationsRepository = new UserGameRepository(context);
            userRepository = new UserRepository(context);
            unitOfWork = new UnitOfWork(context);
        }


        [HttpPost]
        public IHttpActionResult AddDotaAccount(string accountid)
        {
            if (string.IsNullOrEmpty(accountid))
                return BadRequest();

            DotaDataService dotaService = new DotaDataService(accountid);
            DotaDto dotaDto;
            DotaWinsLosesDto dotaWLDto;
            List<DotaMatchDto> dotaMatchesDto;

            try
            {
                dotaDto = dotaService.GetAccountDto();
                dotaWLDto = dotaService.GetWLDto();
                dotaMatchesDto = dotaService.GetMatches();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            string loggedUserId = User.Identity.GetUserId();
            //var ggUser = context.Users
            //    .Where(u => u.Id == loggedUserId)
            //    .Select(u => u.UserAccount)
            //    .SingleOrDefault();
            var ggUser = userRepository.GetLoggedUser(loggedUserId);

            //var userGameRelation = context.UserGameRelations
            //    .Include(ug => ug.GameAccount)
            //    .Include(ug => ug.GameAccount.GameAccountStats)
            //    .SingleOrDefault(ug => ug.GameID == 2 && ug.UserId == ggUser.ID);
            var userGameRelation = userGameRelationsRepository.GetUserGameRelationWithExistingGameWithStats(2, ggUser.ID);


            if (userGameRelation != null && userGameRelation.GameAccount ==null )
            {
                userGameRelation.GameAccount = new GameAccount(dotaDto.profile.personaname, accountid, dotaService.SteamId, dotaDto.profile.loccountrycode);
                userGameRelation.GameAccount.GameAccountStats = new GameAccountStats();
                userGameRelation.GameAccount.GameAccountStats.Update(dotaDto, dotaWLDto, Convert.ToString(dotaService.KDA));
                unitOfWork.Complete();
            }
            else if(userGameRelation == null)
            {
                var newUserGameRelation = UserGame.CreateNewRelationWithAccountDota(ggUser.ID, dotaDto, dotaWLDto, dotaMatchesDto);
                try
                {
                    //context.UserGameRelations.Add(newUserGameRelation);
                    userGameRelationsRepository.Add(newUserGameRelation);
                    unitOfWork.Complete();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                userGameRelation.GameAccount.UpdateAccount(dotaDto);
                userGameRelation.GameAccount.GameAccountStats.Update(dotaDto,dotaWLDto, Convert.ToString(dotaService.KDA));
                unitOfWork.Complete();
            }

            return Ok();

         

        }

        //[HttpGet]
        //public IHttpActionResult CheckAccount(string accountid)
        //{
        //    if (string.IsNullOrEmpty(accountid))
        //        return BadRequest("empty");

        //    //string apikey = "079035b2-9fd0-4f5f-8bde-fde9270029fd";

        //    string url = HttpUtility.UrlPathEncode($"https://api.opendota.com/api/players/{accountid}");

        //    using (WebClient client = new WebClient())
        //    {
        //        string json = client.DownloadString(url);
        //        DotaDto dotaDto;

        //        try
        //        {
        //            dotaDto = (new JavaScriptSerializer().Deserialize<DotaDto>(json));
        //            if (dotaDto.profile == null)
        //                throw new ArgumentNullException();
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(e.Message);
        //        }

        //        return Ok(dotaDto);
        //    }


        //}
    }
}

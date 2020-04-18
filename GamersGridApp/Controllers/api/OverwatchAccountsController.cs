using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Helpers;
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
    public class OverwatchAccountsController : ApiController
    {
        private readonly ApplicationDbContext context;
        private readonly IGameRepository gameRepository;
        private readonly IUserGameRepository userGameRelationsRepository;
        private readonly IUserRepository userRepository;
        private readonly UnitOfWork unitOfWork;

        public OverwatchAccountsController()
        {
            context = new ApplicationDbContext();
            gameRepository = new GameRepository(context);
            userGameRelationsRepository = new UserGameRepository(context);
            userRepository = new UserRepository(context);
            unitOfWork = new UnitOfWork(context);
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        [HttpPost]
        public IHttpActionResult AddAccount(AddOverwatchAccViewModel viewModel)
        {
            if (String.IsNullOrEmpty(viewModel.BattleTag))
                return BadRequest("Name is not set");


            OverwatchDataService overwatchService = new OverwatchDataService(viewModel.BattleTag,viewModel.Region);
            OverWatchCompleteDto owCompleteDto;

            try
            {
                owCompleteDto = overwatchService.GetCompleteProfileDto();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }


            // OverWatchID
            const int overwatchId = 3;

            //geting User
            var appUserId = User.Identity.GetUserId();
            //var user = context.Users
            //    .Where(u => u.Id == appUserId)
            //    .Select(u => u.UserAccount)
            //    .SingleOrDefault();
            var user = userRepository.GetLoggedUser(appUserId);

            //var userGame = context.UserGameRelations
            //    .Include(ga=>ga.GameAccount)
            //    .Include(ga => ga.GameAccount.GameAccountStats)
            //    .SingleOrDefault(ga => ga.UserId == user.ID && ga.GameID == overwatchId);

            var userGame = userGameRelationsRepository.GetUserGameRelationWithExistingGame(overwatchId,user.ID);



            if (userGame != null && userGame.GameAccount == null)
            {
                userGame.GameAccount = new GameAccount(owCompleteDto.name,viewModel.BattleTag,viewModel.Region);
                userGame.GameAccount.GameAccountStats = new GameAccountStats();
                userGame.GameAccount.GameAccountStats.Update(owCompleteDto);
                unitOfWork.Complete();
            }
            else if (userGame == null )
            {
                var newUserGameRelation = UserGame.CreateNewRelationWithAccountOverWatch(user.ID, viewModel.BattleTag, viewModel.Region, owCompleteDto);
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
                userGame.GameAccount.UpdateAccount(owCompleteDto.name, viewModel.BattleTag, viewModel.Region);
                userGame.GameAccount.GameAccountStats.Update(owCompleteDto);
                unitOfWork.Complete();
            }

            return Ok(owCompleteDto);
   
        }

        //[HttpGet]
        //public IHttpActionResult CheckAccount(string battleTag, string region)
        //{
        //    if (String.IsNullOrEmpty(battleTag))
        //        return BadRequest("Name is not set");

        //    battleTag = battleTag.Replace("#", "-");

        //    string url = HttpUtility.UrlPathEncode($"https://ow-api.com/v1/stats/pc/{region}/{battleTag}/profile");
        //    string urlComplete = HttpUtility.UrlPathEncode($"https://ow-api.com/v1/stats/pc/{region}/{battleTag}/complete");

        //    OverWatchProfileDto owProfileDto;
        //    OverWatchCompleteDto owCompleteDto;

        //    string jsonComplete;
        //    using (WebClient client = new WebClient())
        //    {
        //        string json = client.DownloadString(url);
        //        jsonComplete = client.DownloadString(urlComplete);

        //        try
        //        {
        //            owProfileDto = new JavaScriptSerializer().Deserialize<OverWatchProfileDto>(json);
        //            owCompleteDto = new JavaScriptSerializer().Deserialize<OverWatchCompleteDto>(jsonComplete);
        //        }
        //        catch (Exception e)
        //        {
        //            return BadRequest(e.Message);
        //        }
        //    }


        //    return Ok(owCompleteDto);
        //}
    }
}


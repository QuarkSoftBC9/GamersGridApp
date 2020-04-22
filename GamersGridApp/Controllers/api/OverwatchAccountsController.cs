using GamersGridApp.Core;
using GamersGridApp.Core.ApiAcountsDtos;
using GamersGridApp.Core.Dtos.SearchEngine;
using GamersGridApp.Core.Models;
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
    public class OverwatchAccountsController : ApiController
    {

        private readonly IUnitOfWork UnitOfWork;

        public OverwatchAccountsController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }


        [HttpGet]
        public IHttpActionResult GetStats(string battleTag, string region)
        {
            if (String.IsNullOrEmpty(battleTag) || string.IsNullOrEmpty(region))
                return BadRequest();


            OverwatchDataService overwatchService = new OverwatchDataService(battleTag, region);
            OverWatchCompleteDto owCompleteDto;

            try
            {
                owCompleteDto = overwatchService.GetCompleteProfileDto();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
            OverwatchSearchDto searchDto = new OverwatchSearchDto(owCompleteDto,battleTag,region);
            
            return Ok(searchDto);
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
            var user = UnitOfWork.GGUsers.GetLoggedUser(appUserId);

            //var userGame = context.UserGameRelations
            //    .Include(ga=>ga.GameAccount)
            //    .Include(ga => ga.GameAccount.GameAccountStats)
            //    .SingleOrDefault(ga => ga.UserId == user.ID && ga.GameID == overwatchId);

            var userGame = UnitOfWork.UserGames.GetUserGameRelationWithExistingGame(overwatchId,user.ID);



            if (userGame != null && userGame.GameAccount == null)
            {
                userGame.GameAccount = new GameAccount(owCompleteDto.name,viewModel.BattleTag,viewModel.Region);
                userGame.GameAccount.GameAccountStats = new GameAccountStats();
                userGame.GameAccount.GameAccountStats.Update(owCompleteDto);
                UnitOfWork.Complete();
            }
            else if (userGame == null )
            {
                var newUserGameRelation = UserGame.CreateNewRelationWithAccountOverWatch(user.ID, viewModel.BattleTag, viewModel.Region, owCompleteDto);
                try
                {
                    //context.UserGameRelations.Add(newUserGameRelation);
                    UnitOfWork.UserGames.Add(newUserGameRelation);
                    UnitOfWork.Complete();
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
                UnitOfWork.Complete();
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


using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Helpers;
using GamersGridApp.Models;
using GamersGridApp.ViewModels;
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

        public OverwatchAccountsController()
        {
            context = new ApplicationDbContext();
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

            


            string url = HttpUtility.UrlPathEncode($"https://ow-api.com/v1/stats/pc/{viewModel.Region}/{viewModel.GetBattleTag()}/profile");
            string urlComplete = HttpUtility.UrlPathEncode($"https://ow-api.com/v1/stats/pc/{viewModel.Region}/{viewModel.GetBattleTag()}/complete");

            OverWatchProfileDto owProfileDto;
            OverWatchCompleteDto owCompleteDto;


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                string jsonComplete = client.DownloadString(urlComplete);

                try
                {
                    owProfileDto = new JavaScriptSerializer().Deserialize<OverWatchProfileDto>(json);
                    owCompleteDto = new JavaScriptSerializer().Deserialize<OverWatchCompleteDto>(jsonComplete);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            // OverWatchID
            const int overwatchId = 4;


            //geting User
            var appUserId = User.Identity.GetUserId();
            var user = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .SingleOrDefault();

            //if (userContent == null)

            var userGame = context.UserGameRelations
                .Include(ga=>ga.GameAccount)
                .Include(ga => ga.GameAccount.GameAccountStats)
                .SingleOrDefault(ga => ga.UserId == user.ID && ga.GameID == overwatchId);

            string kda = Convert.ToString(ExtraMethods.CalculateKda(
                owCompleteDto.competitiveStats.careerStats.allHeroes.average.deathsAvgPer10Min,
                owCompleteDto.competitiveStats.careerStats.allHeroes.average.eliminationsAvgPer10Min));

            if (userGame == null)
            {
                var newUserGameRelation = UserGame.CreateNewRelationWithAccountOverWatch(overwatchId, user.ID, owProfileDto.name, viewModel.Region, viewModel.BattleTag, owCompleteDto.gamesWon, 0, kda);
                try
                {
                    context.UserGameRelations.Add(newUserGameRelation);
                    context.SaveChanges();
                }catch(Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                userGame.GameAccount.UpdateAccount(owProfileDto.name, viewModel.BattleTag, viewModel.Region);
                userGame.GameAccount.GameAccountStats.Update(kda, owCompleteDto.gamesWon, 0, Convert.ToString(owProfileDto.rating));
                context.SaveChanges();
            }

            return Ok(owCompleteDto);
   
        }

        [HttpGet]
        public IHttpActionResult CheckAccount(string battleTag, string region)
        {
            if (String.IsNullOrEmpty(battleTag))
                return BadRequest("Name is not set");

            battleTag = battleTag.Replace("#", "-");

            string url = HttpUtility.UrlPathEncode($"https://ow-api.com/v1/stats/pc/{region}/{battleTag}/profile");
            string urlComplete = HttpUtility.UrlPathEncode($"https://ow-api.com/v1/stats/pc/{region}/{battleTag}/complete");

            OverWatchProfileDto owProfileDto;
            OverWatchCompleteDto owCompleteDto;

            string jsonComplete;
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                jsonComplete = client.DownloadString(urlComplete);

                try
                {
                    owProfileDto = new JavaScriptSerializer().Deserialize<OverWatchProfileDto>(json);
                    owCompleteDto = new JavaScriptSerializer().Deserialize<OverWatchCompleteDto>(jsonComplete);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }


            return Ok(owCompleteDto);
        }
    }
}


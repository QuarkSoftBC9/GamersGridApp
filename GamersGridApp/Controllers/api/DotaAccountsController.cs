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

namespace GamersGridApp.Controllers.api
{
    public class DotaAccountsController : ApiController
    {
        private ApplicationDbContext context;

        public DotaAccountsController()
        {
            context = new ApplicationDbContext();
        }


        [HttpPost]
        public IHttpActionResult AddDotaAccount(string accountid)
        {
            if (string.IsNullOrEmpty(accountid))
                return BadRequest();

            string url = HttpUtility.UrlPathEncode($"https://api.opendota.com/api/players/{accountid}");
            string urlWinsLoses = HttpUtility.UrlPathEncode($"https://api.opendota.com/api/players/{accountid}/wl");
            string urlRecentMatches = HttpUtility.UrlPathEncode($"https://api.opendota.com/api/players/{accountid}/recentMatches");

            DotaDto dotaDto;
            DotaWinsLosesDto dotaWLDto;
            List<DotaMatch> dotaMatches;

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                string jsonWL = client.DownloadString(urlWinsLoses);
                string jsonMatches = client.DownloadString(urlRecentMatches);
                try
                {
                    dotaDto = (new JavaScriptSerializer().Deserialize<DotaDto>(json));
                    dotaWLDto = (new JavaScriptSerializer().Deserialize<DotaWinsLosesDto>(jsonWL));
                    dotaMatches = (new JavaScriptSerializer().Deserialize<List<DotaMatch>>(jsonMatches));
                    if (dotaDto.profile == null)
                        throw new ArgumentNullException();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }

            string loggedUserId = User.Identity.GetUserId();
            var ggUser = context.Users
                .Where(u => u.Id == loggedUserId)
                .Select(u => u.UserAccount)
                .SingleOrDefault();

            var userGameRelation = context.UserGameRelations
                .Include(ug => ug.GameAccount)
                .Include(ug => ug.GameAccount.GameAccountStats)
                .SingleOrDefault(ug => ug.GameID == 3 && ug.UserId == ggUser.ID);
            var kda = ExtraMethods.CalculateKda(dotaMatches);

            if (userGameRelation == null)
            {
                var newUserGameRelation = UserGame.CreateNewRelationWithAccountDota(3, ggUser.ID, dotaDto.profile.personaname, accountid, dotaWLDto.win, dotaWLDto.lose, Convert.ToString(kda));
            try
                {
                    context.UserGameRelations.Add(newUserGameRelation);
                    context.SaveChanges();
                }
                catch
                {
                    return BadRequest();
                }
                return Ok();

            }
            else
            {

                userGameRelation.GameAccount.UpdateAccount(dotaDto.profile.personaname, accountid,null);
                userGameRelation.GameAccount.GameAccountStats.Update(Convert.ToString(kda), dotaWLDto.win, dotaWLDto.lose);
                context.SaveChanges();

                return Ok();
            }


        }

        [HttpGet]
        public IHttpActionResult GetStats(string accountid)
        {
            if (string.IsNullOrEmpty(accountid))
                return BadRequest();

            //string apikey = "079035b2-9fd0-4f5f-8bde-fde9270029fd";

            string url = HttpUtility.UrlPathEncode($"https://api.opendota.com/api/players/{accountid}");

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                DotaDto dotaDto;

                try
                {
                    dotaDto = (new JavaScriptSerializer().Deserialize<DotaDto>(json));
                    if (dotaDto.profile == null)
                        throw new ArgumentNullException();
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }

                return Ok(dotaDto);
            }


        }
    }
}

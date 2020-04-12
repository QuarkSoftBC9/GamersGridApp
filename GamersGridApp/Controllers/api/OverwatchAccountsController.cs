﻿using GamersGridApp.Dtos.ApiAcountsDtos;
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
            if (String.IsNullOrEmpty(viewModel.UserName))
                return BadRequest("Name is not set");
            // OverWatchID
            int overwatchID = context.Games
                .Where(g => g.Title == "Overwatch")
                .Select(g => g.ID)
                .SingleOrDefault();

            //geting UserContent
            var appUserId = User.Identity.GetUserId();
            var userContent = context.Users
                .Where(u => u.Id == appUserId)
                .Select(u => u.UserAccount)
                .Include(g => g.UserGames.Select(ga => ga.GameAccount))
                .SingleOrDefault();
            if (userContent == null)
                return BadRequest("User could not be found");

            var userGame = userContent.UserGames.SingleOrDefault(g => g.GameID == overwatchID);

            //api no key required
            string userName = viewModel.GetBattleTag();
            var url = String.Format("https://ow-api.com/v1/stats/pc/{0}/{1}/profile",
                viewModel.Region, userName);

            url = HttpUtility.UrlPathEncode(url);

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);

                OverWatchDto rootAccount = (new JavaScriptSerializer()).Deserialize<OverWatchDto>(json);

                if (userGame == null)
                {
                    //GameAccount newAccount = new GameAccount(viewModel.UserName, userName, viewModel.Region) { };
                    //newAccount.GameAccountStats = new GameAccountStats(newAccount, rootAccount.rating.ToString(),
                    //    rootAccount.competitiveStats.games.won,
                    //    (rootAccount.competitiveStats.games.played - rootAccount.competitiveStats.games.won));
                    //userContent.UserGames.Add(new UserGame(overwatchID, userContent.ID, newAccount));
                }
                else
                    userGame.GameAccount.UpdateAccount(viewModel.UserName, userName, viewModel.Region);

                context.SaveChanges();
                return Ok("All good");
            }

        }
        //get overwatch stats 

    }
}

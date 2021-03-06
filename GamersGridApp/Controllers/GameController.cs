﻿using GamersGridApp.Core;
using GamersGridApp.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamersGridApp.Controllers
{
    public class GameController : Controller
    {

        private readonly IUnitOfWork UnitOfWork;


        public GameController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;

        }
        // GET: Game
        public ViewResult Index()
        {
            var games = UnitOfWork.Games.GetGames().ToList();
            return View("Games", games);
            //return View("GamesList");
        }


        public ActionResult GameProfile(string gameName)
        {
            //if (gameName == null)
            //    return RedirectToAction("Index");

            //var game = dbContext.Games.SingleOrDefault(g => g.Title == gameName);

            //if(game == null)
            //    return RedirectToAction("Index");

            //testing
            //var gameTest = dbContext.Games.SingleOrDefault(g => g.Title.Contains(gameName));
            var gameTest = UnitOfWork.Games.GetGame(gameName);

            //var usersFocusing = dbContext.UserGameRelations.Where(g => g.Game.Title == gameTest.Title && g.IsFavoriteGame == true).Select(g => g.GameID).ToList();
            var usersFocusing = UnitOfWork.UserGames.GetGamesIdFocus(gameTest);

            var numberOfUsersFocusing = usersFocusing.Count();

            var profileGame = new ProfileGameViewModel()
            {
                Game = gameTest,
                UsersFocusing = numberOfUsersFocusing
            };
            return View(profileGame);
        }
    }
}
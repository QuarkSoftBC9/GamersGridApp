
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using GamersGridApp.Core;
using GamersGridApp.Core.Models;
using GamersGridApp.Core.Dtos;

using GamersGridApp.Perstistence;

namespace GamersGridApp.Controllers.api
{
    public class GamesController : ApiController
    {

        private readonly IUnitOfWork UnitOfWork;

        public GamesController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }

        //GET : /api/games
        [HttpGet]
        public IHttpActionResult GetGames(string query = null)
        {
            //var gamesQuery = dbContext.Games.AsQueryable();
            var gamesQuery = UnitOfWork.Games.GetGames();

            if (!String.IsNullOrEmpty(query))
                gamesQuery = gamesQuery.Where(g => g.Title.Contains(query));

            var games = gamesQuery.ToList()
                .Select(Mapper.Map<Game, GameDto>);

            return Ok(games);
        }
    }
}

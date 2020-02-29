using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using GamersGridApp.Dtos;

namespace GamersGridApp.Controllers.api
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext dbContext;
        public GamesController()
        {
            dbContext = new ApplicationDbContext();
        }

        //GET : /api/games
        [HttpGet]
        public IHttpActionResult GetGames(string query = null)
        {
            var gamesQuery = dbContext.Games.AsQueryable();

            if (!String.IsNullOrEmpty(query))
                gamesQuery = gamesQuery.Where(g => g.Title.Contains(query));

            var games = gamesQuery.ToList()
                .Select(Mapper.Map<Game, GameDto>);

            return Ok(games);
        }
    }
}

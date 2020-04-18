using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using GamersGridApp.Dtos;
using GamersGridApp.Repositories;
using GamersGridApp.Perstistence;

namespace GamersGridApp.Controllers.api
{
    public class GamesController : ApiController
    {
        private ApplicationDbContext dbContext;
        //private readonly IGameRepository gameRepository;
        //private readonly IUserGameRepository userGameRelationsRepository;
        //private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        //private readonly IFollowsRepository followsRepository;
        public GamesController()
        {
            dbContext = new ApplicationDbContext();
            //gameRepository = new GameRepository(dbContext);
            //userGameRelationsRepository = new UserGameRepository(dbContext);
            //userRepository = new UserRepository(dbContext);
            unitOfWork = new UnitOfWork(dbContext);
            //followsRepository = new FollowsRepository(dbContext);
        }

        //GET : /api/games
        [HttpGet]
        public IHttpActionResult GetGames(string query = null)
        {
            //var gamesQuery = dbContext.Games.AsQueryable();
            var gamesQuery = unitOfWork.Games.GetGames();

            if (!String.IsNullOrEmpty(query))
                gamesQuery = gamesQuery.Where(g => g.Title.Contains(query));

            var games = gamesQuery.ToList()
                .Select(Mapper.Map<Game, GameDto>);

            return Ok(games);
        }
    }
}

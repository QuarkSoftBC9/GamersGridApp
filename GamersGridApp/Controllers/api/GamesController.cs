using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        public IHttpActionResult GetGames(string query = null)
        {


            return Ok();
        }
    }
}

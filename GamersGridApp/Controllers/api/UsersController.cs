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
    public class UsersController : ApiController
    {

        private ApplicationDbContext context;
        //private readonly IGameRepository gameRepository;
        //private readonly IUserGameRepository userGameRelationsRepository;
        //private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;
        public UsersController()
        {
            context = new ApplicationDbContext();
            //gameRepository = new GameRepository(context);
            //userGameRelationsRepository = new UserGameRepository(context);
            //userRepository = new UserRepository(context);
            unitOfWork = new UnitOfWork(context);
        }

        //GET : /api/users
        [HttpGet]
        public IHttpActionResult GetUsers(string query = null)
        {
            //var gamersQuery = dbContext.GamersGridUsers.AsQueryable();
            var gamersQuery = unitOfWork.Users.GetUsers();

            //Do work here !!!!
            IEnumerable<UserDto> search;
            //We check if the search string is contained in NickName/FirstName/LastName and take the first 5 elements
            if (!String.IsNullOrEmpty(query))
            {
                //search = dbContext.GamersGridUsers
                //.Where(u => u.LastName.Contains(query) || u.FirstName.Contains(query) || u.NickName.Contains(query))
                //.ToList()
                //.Select(Mapper.Map<User, UserDto>);
                search = unitOfWork.Users.BetterSearchUsers(query).Select(Mapper.Map<User, UserDto>);
                return Ok(search);
            }

            var gamers = gamersQuery
                .Select(Mapper.Map<User, UserDto>);

            return Ok(gamers);

        }
    }
}
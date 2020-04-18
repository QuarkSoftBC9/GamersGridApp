
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;

using GamersGridApp.Perstistence;
using GamersGridApp.Core;
using GamersGridApp.Core.Dtos;
using GamersGridApp.Core.Models;

namespace GamersGridApp.Controllers.api
{
    public class UsersController : ApiController
    {


        private readonly IUnitOfWork UnitOfWork;
        public UsersController(IUnitOfWork unitofWork)
        {
            UnitOfWork = unitofWork;
        }

        //GET : /api/users
        [HttpGet]
        public IHttpActionResult GetUsers(string query = null)
        {
            //var gamersQuery = dbContext.GamersGridUsers.AsQueryable();
            var gamersQuery = UnitOfWork.GGUsers.GetUsers();

            //Do work here !!!!
            IEnumerable<UserDto> search;
            //We check if the search string is contained in NickName/FirstName/LastName and take the first 5 elements
            if (!String.IsNullOrEmpty(query))
            {
                //search = dbContext.GamersGridUsers
                //.Where(u => u.LastName.Contains(query) || u.FirstName.Contains(query) || u.NickName.Contains(query))
                //.ToList()
                //.Select(Mapper.Map<User, UserDto>);
                search = UnitOfWork.GGUsers.BetterSearchUsers(query).Select(Mapper.Map<User, UserDto>);
                return Ok(search);
            }

            var gamers = gamersQuery
                .Select(Mapper.Map<User, UserDto>);

            return Ok(gamers);

        }
    }
}
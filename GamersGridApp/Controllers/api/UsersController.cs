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
    public class UsersController : ApiController
    {

        private ApplicationDbContext dbContext;
        public UsersController()
        {
            dbContext = new ApplicationDbContext();
        }

        //GET : /api/users
        [HttpGet]
        public IHttpActionResult GetUsers(string query = null)
        {
            var usersQuery = dbContext.GamersGridUsers.AsQueryable();

            if (!String.IsNullOrEmpty(query))
                usersQuery = usersQuery.Where(u => u.FirstName.Contains(query));

            var users = usersQuery.ToList()
                .Select(Mapper.Map<User, UserDto>);

            return Ok(users);
        }
    }
}
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
            IEnumerable<UserDto> search;
            //We check if the search string is contained in NickName/FirstName/LastName and take the first 5 elements
            if (!String.IsNullOrEmpty(query))
            {
                search = dbContext.GamersGridUsers
                .Where(u => u.LastName.Contains(query) || u.FirstName.Contains(query) || u.NickName.Contains(query))
                .ToList()
                .Select(Mapper.Map<User, UserDto>);
                return Ok(search);
            }
            return Ok();

        }
    }
}
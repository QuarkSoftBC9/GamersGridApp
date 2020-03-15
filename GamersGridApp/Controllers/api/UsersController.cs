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


            //Typeahead train data 
            var usersTrain = new List<User>()
            {
                new User(){FirstName = "Stanislav", LastName = "Novikov", NickName = "LeagueWarrior"},
                new User(){FirstName = "John", LastName = "Lezhino", NickName = "JohnLez"},
                new User(){FirstName = "Chris", LastName = "Antonopoulos", NickName = "ChrisA"},
                new User(){FirstName = "Maria", LastName = "Ntourmetaki", NickName = "Leaguer"},
                new User(){FirstName = "Avraam", LastName = "Liautsis", NickName = "Lincoln"}
            };
            //We check if the search string is contained in NickName/FirstName/LastName and take the first 5 elements
            var search = usersTrain.Where(u => u.NickName.Contains(query) || u.FirstName.Contains(query) || u.LastName.Contains(query))
                .Take(5)
                .ToList()
                .Select(Mapper.Map<User, UserDto>);

            return Ok(search);
        }

    }
}
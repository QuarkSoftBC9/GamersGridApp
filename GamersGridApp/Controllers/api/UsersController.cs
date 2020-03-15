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


            //Typeahead and DataTables train data 
            var usersTrain = new List<User>()
            {
                new User(){ID = 1, FirstName = "Stanislav", LastName = "Novikov", NickName = "LeagueWarrior", City = "Vladivostok", Country = "Russia"},
                new User(){ID = 2, FirstName = "John", LastName = "Lezhino", NickName = "JohnLez", City = "Angers", Country = "France"},
                new User(){ID = 3, FirstName = "Chris", LastName = "Antonopoulos", NickName = "ChrisA", City = "Athens", Country ="Greece"},
                new User(){ID = 4, FirstName = "Maria", LastName = "Ntourmetaki", NickName = "Leaguer", City = "Heraklion", Country = "Greece"},
                new User(){ID = 5, FirstName = "Avraam", LastName = "Liautsis", NickName = "Lincoln", City = "New York", Country = "USA"}
            };
            
            IEnumerable<UserDto> search;
            //We check if the search string is contained in NickName/FirstName/LastName and take the first 5 elements
            if (String.IsNullOrEmpty(query))
            {
                search = usersTrain
                .Take(5)
                .ToList()
                .Select(Mapper.Map<User, UserDto>);
            }
            else //If search string IS NULL then we just take the first 5 elements 
            {
                search = usersTrain.Where(u => u.NickName.Contains(query) || u.FirstName.Contains(query) || u.LastName.Contains(query))
                .Take(5)
                .ToList()
                .Select(Mapper.Map<User, UserDto>);
            }
            

            return Ok(search);
        }

    }
}
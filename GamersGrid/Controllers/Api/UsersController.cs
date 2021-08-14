﻿using GamersGrid.BLL;
using GamersGrid.DAL;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUnitOfWork unitOfWork;


        public UsersController(ILogger<UsersController> logger,
            IUnitOfWork workUnit)
        {
            _logger = logger;
            unitOfWork = workUnit;
        }

        [HttpGet]
        public async Task<List<GGUserSimpleDto>> GetUsers(int count = 200)
        {
            List<GGUserSimpleDto> returnList = new();

            var users =  await unitOfWork.GGUsers.GetAll();
            var top200Users = users.Take(200);
            top200Users.ToList().ForEach(u =>  returnList.Add(GGUserSimpleDto.CreateFromUser(u)));

            return returnList;

        }
    }
}

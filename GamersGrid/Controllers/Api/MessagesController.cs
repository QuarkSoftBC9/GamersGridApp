using GamersGrid.BLL;
using GamersGrid.DAL.Models.Identity;
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
    public class MessagesController : ControllerBase
    {
        private readonly ILogger<MessagesController> _logger;
        private readonly IUnitOfWork unitOfWork;


        public MessagesController(ILogger<MessagesController> logger,
            IUnitOfWork workUnit)
        {
            _logger = logger;
            unitOfWork = workUnit;
        }

        [HttpGet]
        public async Task<IActionResult> FindMutualFollowers()
        {
            var userId = User.Claims.First().Value;

            var users = await unitOfWork.FollowRelations.GetMessageUsersRelation(int.Parse(userId));

            return Ok(users);
        }
    }
}

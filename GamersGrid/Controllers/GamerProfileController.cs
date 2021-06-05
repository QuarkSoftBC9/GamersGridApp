using GamersGrid.BLL;
using GamersGrid.DAL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Helpers;
using GamersGrid.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Controllers
{
    [Authorize]
    public class GamerProfileController : Controller
    {
        private readonly SignInManager<GGuser> _signInManager;
        private readonly UserManager<GGuser> _userManager;
        private readonly ILogger<GamerProfileController> _logger;
        private readonly CustomHelperService _helperService;
        private readonly IUnitOfWork unitOfWork;

        public GamerProfileController(ILogger<GamerProfileController> logger,
            SignInManager<GGuser> signInManager,
            UserManager<GGuser> userManager,
            CustomHelperService helperService,
            IUnitOfWork workUnit)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _helperService = helperService;
            unitOfWork = workUnit;
        }
        //public IActionResult Index()
        //{

        //    return View("UsersList");
        //}

        [HttpGet]
        public async Task<ActionResult> Index(int? userid)
        {
            //Get currently logged user
            var currentLoggedUser = await _userManager.GetUserAsync(User);

            //identify if parameter "userid" is of logged user or another one, and fetch his profile
            var user = (userid == null) ? currentLoggedUser : unitOfWork.GGUsers.GetUser(userid);

            if (user == null)
                return NotFound();

            //Get user's favorite game
            var userGameRelation = await unitOfWork.UsersGamesRelations
                .GetFirstOrDefault(ugr => ugr.UserId == user.Id && ugr.IsFavoriteGame);

            var favoriteGame = await unitOfWork.Games.Get(userGameRelation.GameId);


            //preparing viewmodel of searched user
            var viewModel = new UserProfilePageVM()
            {
                FollowsCount = await unitOfWork.FollowRelations.GetFollowersCount(user.Id),
                FollowingCount = await unitOfWork.FollowRelations.GetFollowingsCount(user.Id),
                User = user,
                FavouriteGame = favoriteGame,
                FavoriteGameID = favoriteGame.Id
            };

            //variables bound in viewmodel to be used for razor page logic between profile page and current logged user
            if (currentLoggedUser.Id == user.Id)
            {
                viewModel.IsCurrent = true;
                viewModel.LoggedUserId = currentLoggedUser.Id;
            }
            else
            {
                //var followRelation = context.Follows.SingleOrDefault(f => f.FollowerId == currentLoggedUser.ID && f.UserId == user.ID);
                var followRelation = await unitOfWork.FollowRelations.GetFollowRelationOfTwoUsers(currentLoggedUser.Id, user.Id);
                if (followRelation == null)
                    viewModel.IsFollowing = false;
                else
                    viewModel.IsFollowing = true;

                viewModel.IsCurrent = false;
                viewModel.LoggedUserId = currentLoggedUser.Id;
            }

            //Get game accounts of user and their stats
            var gameAccounts = await unitOfWork.GameAccounts.GetAll(gameAccount => gameAccount.UserId == user.Id, includeProperties: "Statistics,Game");

            var gameStatsMappings = new Dictionary<string, GameAccountStats>();
            foreach (var gameAccount in gameAccounts)
            {
                gameStatsMappings.Add(gameAccount.Game.Title, gameAccount.Statistics);
            }
            viewModel.GamesStats = gameStatsMappings;


            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            //Get currently logged user
            var currentLoggedUser = await _userManager.GetUserAsync(User);

            var userGameAccounts = await unitOfWork.GameAccounts.GetAll(gameAccount => gameAccount.UserId == currentLoggedUser.Id);

            var userEditVM = new UserEditVM(currentLoggedUser, userGameAccounts.ToList());

            return View("Edit", userEditVM);
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserEditVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                user.Update(
                    model.FirstName, model.LastName, model.NickName,
                    model.Description, model.Country, model.City);

                if (model.AvatarImage != null)
                    user.UpdateAvatar(await _helperService.SaveAvatar(model.AvatarImage, user.Avatar));

                await unitOfWork.Save();

            }

            return RedirectToAction("Edit", model);
        }

        [HttpGet]
        public async Task<IActionResult> TestHub()     
        {
            return View();
        }

    }
}

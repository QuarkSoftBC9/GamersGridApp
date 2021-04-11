using GamersGrid.BLL;
using GamersGrid.DAL;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Helpers;
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
    public class UserController : Controller
    {
        private readonly SignInManager<GGuser> _signInManager;
        private readonly UserManager<GGuser> _userManager;
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly CustomHelperService _helperService;
        private readonly IUnitOfWork unitOfWork;

        public UserController(ILogger<UserController> logger,
            ApplicationDbContext dbContext,
            SignInManager<GGuser> signInManager,
            UserManager<GGuser> userManager,
            CustomHelperService helperService,
            UnitOfWork workUnit)
        {
            _logger = logger;
            _db = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _helperService = helperService;
            unitOfWork = workUnit;
        }
        public IActionResult Index()
        {
            return View("UsersList");
        }

        //[Authorize]
        //public ActionResult ProfilePage(int? userid)
        //{
        //    //GET LOGGED USER 

        //    //GET searched USER
        //    //if (searched USER == null)
        //    //    return HttpNotFound();

        //    //GET searched user favorite game 
        //    //get searched user followers and followees count
        //    //build PROFILE VIEWMODEL

        //    //if searched user == logged user 
        //    //viewModel.IsCurrent = true;
        //    //viewModel.LoggedUserId = currentLoggedUser.ID;
        //    //else 
        //    //var followRelation = context.Follows.SingleOrDefault(f => f.FollowerId == currentLoggedUser.ID && f.UserId == user.ID);
        //    //var followRelation = UnitOfWork.Follows.GetFollowRelationOfTwoUsers(currentLoggedUser.ID, user.ID);
        //    //if (followRelation == null)
        //    //    viewModel.IsFollowing = false;
        //    //else
        //    //    viewModel.IsFollowing = true;

        //    //var userGames = UnitOfWork.UserGames.GetUserGamesStats(user.ID);

        //    //bool accountsFilled = true;

        //    //foreach (var usergame in userGames)
        //    //{
        //    //    if (usergame.GameAccount == null)
        //    //        accountsFilled = false;
        //    //}

        //    //if (accountsFilled)
        //    //{
        //    //    //viewModel.GamesStats = userGames
        //    //    //    .Where(u => u.UserId == user.ID)
        //    //    //    .Select(ga => ga.GameAccount.GameAccountStats)
        //    //    //    .ToDictionary(g => g.GameAccount.UserGame.Game.Title);

        //    //    viewModel.GamesStats = UnitOfWork.UserGames.GetGamesTitlesDict(userGames, user.ID);
        //    //}

        //    //return View(viewModel)

        //    //viewModel.IsCurrent = false;
        //    //viewModel.LoggedUserId = currentLoggedUser.ID;

        //    ////current logged user 
        //    //var loggedUserId = User.Identity.GetUserId();
        //    ////var currentLoggedUser = context.Users.Where(u => u.Id == loggedUserId).Select(u => u.UserAccount).SingleOrDefault();
        //    //var currentLoggedUser = UnitOfWork.GGUsers.GetLoggedUser(loggedUserId);

        //    ////var user = (userid == null) ? currentLoggedUser : context.GamersGridUsers.SingleOrDefault(u => u.ID == userid);
        //    //var user = (userid == null) ? currentLoggedUser : UnitOfWork.GGUsers.GetUser(userid);

        //    ////var favoritegame = context.UserGames.Where(d => d.UserId == userId).Select(d => d.UserAccount).SingleOrDefault();

        //    ////var favoritegameID = context.UserGameRelations.Where(u => u.UserId == user.ID && u.IsFavoriteGame == true).Select(g => g.GameID).SingleOrDefault();
        //    //var favoritegameID = UnitOfWork.Games.GetFavouriteGameId(user.ID);

        //    ////var favoritegame = context.Games.Include(g => g.ID == favoritegameID).SingleOrDefault();

        //    ////var favoritegame = context.Games
        //    ////  .Where(g => g.ID == favoritegameID)
        //    ////  .SingleOrDefault();
        //    //if (favoritegameID == 0)
        //    //    favoritegameID = 3;
        //    //var favoritegame = UnitOfWork.Games.GetFavouriteGame(favoritegameID);

        //    //if (user == null)
        //    //    return HttpNotFound();

        //    ////preparing viewmodel of searched user
        //    //var viewModel = new UserProfilePageViewModel()
        //    //{
        //    //    FollowsCount = UnitOfWork.Follows.GetFollowersCount(user.ID),
        //    //    FollowingCount = UnitOfWork.Follows.GetFollowingsCount(user.ID),
        //    //    User = user,
        //    //    FavouriteGame = favoritegame,
        //    //    FavoriteGameID = favoritegameID
        //    //};

        //    ////variables bound in viewmodel to be used for razor page logic between profile page and current logged user
        //    //if (currentLoggedUser.ID == user.ID)
        //    //{
        //    //    viewModel.IsCurrent = true;
        //    //    viewModel.LoggedUserId = currentLoggedUser.ID;
        //    //}
        //    //else
        //    //{
        //    //    //var followRelation = context.Follows.SingleOrDefault(f => f.FollowerId == currentLoggedUser.ID && f.UserId == user.ID);
        //    //    var followRelation = UnitOfWork.Follows.GetFollowRelationOfTwoUsers(currentLoggedUser.ID, user.ID);
        //    //    if (followRelation == null)
        //    //        viewModel.IsFollowing = false;
        //    //    else
        //    //        viewModel.IsFollowing = true;

        //    //    viewModel.IsCurrent = false;
        //    //    viewModel.LoggedUserId = currentLoggedUser.ID;
        //    //}
        //    ////including stats 
        //    ////var userGames = context.UserGameRelations
        //    ////    .Where(u => u.UserId == user.ID)
        //    ////    .Include(g => g.Game)
        //    ////    .Include(ga => ga.GameAccount)
        //    ////    .Include(gs => gs.GameAccount.GameAccountStats).ToList();

        //    //var userGames = UnitOfWork.UserGames.GetUserGamesStats(user.ID);

        //    //bool accountsFilled = true;

        //    //foreach (var usergame in userGames)
        //    //{
        //    //    if (usergame.GameAccount == null)
        //    //        accountsFilled = false;
        //    //}

        //    //if (accountsFilled)
        //    //{
        //    //    //viewModel.GamesStats = userGames
        //    //    //    .Where(u => u.UserId == user.ID)
        //    //    //    .Select(ga => ga.GameAccount.GameAccountStats)
        //    //    //    .ToDictionary(g => g.GameAccount.UserGame.Game.Title);

        //    //    viewModel.GamesStats = UnitOfWork.UserGames.GetGamesTitlesDict(userGames, user.ID);
        //    //}

        //    //return View(viewModel);
        //}


    }
}

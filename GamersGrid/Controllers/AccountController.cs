using GamersGrid.DAL;
using GamersGrid.DAL.Models;
using GamersGrid.DAL.Models.Identity;
using GamersGrid.Helpers;
using GamersGrid.Models.Account;
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
    public class AccountController : Controller
    {
        private readonly SignInManager<GGuser> _signInManager;
        private readonly UserManager<GGuser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly CustomHelperService _helperService;

        public AccountController(ILogger<AccountController> logger,
            ApplicationDbContext dbContext,
            SignInManager<GGuser> signInManager,
            UserManager<GGuser> userManager,
            CustomHelperService helperService)
        {
            _logger = logger;
            _db = dbContext;
            _signInManager = signInManager;
            _userManager = userManager;
            _helperService = helperService;
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            RegisterVM model = new RegisterVM() { };
            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                GGuser newUser = model.ExportGGUser();
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if(result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: false);

                    var userObj = await _userManager.FindByEmailAsync(model.Email);

                    if (model.AvatarImage != null)
                        userObj.Avatar = await _helperService.SaveAvatar(model.AvatarImage);

                    var favoriteGame = _db.Games.First(g => g.Title == model.FavoriteGame);
                    UsersGamesRelation newUserGameRelation = new(userObj.Id, favoriteGame.Id);
                    userObj.GamesRelations.Add(newUserGameRelation);

                    await _db.SaveChangesAsync();
                    return RedirectToAction("ProfilePage", "User", new { userid = userObj.Id });
                }
            }

            return View(model);
        }


    }
}

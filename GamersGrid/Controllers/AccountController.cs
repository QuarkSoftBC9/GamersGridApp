using GamersGrid.BLL;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly CustomHelperService _helperService;

        public AccountController(ILogger<AccountController> logger,
            SignInManager<GGuser> signInManager,
            UserManager<GGuser> userManager,
            CustomHelperService helperService,
            IUnitOfWork uow)
        {
            _logger = logger;
            unitOfWork = uow;
            _signInManager = signInManager;
            _userManager = userManager;
            _helperService = helperService;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
            //return RedirectToAction("ProfilePage", "User", new { userid = userContent.ID });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM model, string returnUrl)

        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                return RedirectToAction("Index", "GamerProfile");
            }
            else if (result.IsLockedOut)
                return View("Lockout");
            //else if (result.RequiresTwoFactor)
            //    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(model);
            }
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
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                GGuser newUser = model.ExportGGUser();
                var result = await _userManager.CreateAsync(newUser, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser, isPersistent: false);

                    var userObj = await _userManager.FindByEmailAsync(model.Email);

                    if (model.AvatarImage != null)
                        userObj.Avatar = await _helperService.SaveAvatar(model.AvatarImage);

                    var favoriteGame = await unitOfWork.Games.GetFirstOrDefault(g => g.Title == model.FavoriteGame);
                    UsersGamesRelation newUserGameRelation = new(userObj.Id, favoriteGame.Id);
                    userObj.GamesRelations = new List<UsersGamesRelation>();
                    userObj.GamesRelations.Add(newUserGameRelation);

                    await unitOfWork.Save();
                    return RedirectToAction("Index", "GamerProfile");
                }
            }

            return View(model);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }

    }
}

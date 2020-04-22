using GamersGridApp.Core;
using GamersGridApp.Core.Models;
using GamersGridApp.Core.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GamersGridApp.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        private readonly IUnitOfWork UnitOfWork;

        public TeamController(IUnitOfWork unitofwork)
        {
            UnitOfWork = unitofwork;
        }

        // GET: Teams
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Team(int id)
        {
            var appUserId = User.Identity.GetUserId();
            var user = UnitOfWork.GGUsers.GetUser(appUserId);
            var team = UnitOfWork.Teams.GetTeam(id);

            return View(team);
        }
        public ActionResult New()
        {
            var appUserId = User.Identity.GetUserId();
            var user = UnitOfWork.GGUsers.GetUserContent(appUserId);
            NewTeamViewModel viewModel = new NewTeamViewModel(new Team(user.ID), UnitOfWork.Games.GetGames());
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(NewTeamViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Games = UnitOfWork.Games.GetGames();
                return View("New", viewModel);
            }
            var team = viewModel.Team;
            UnitOfWork.Teams.AddTeam(team);
            UnitOfWork.Complete();
            var teamSaved = UnitOfWork.Teams.GetTeamByName(team.Name);
            return RedirectToAction("Team", "Team", teamSaved.ID );
        }
    }
}
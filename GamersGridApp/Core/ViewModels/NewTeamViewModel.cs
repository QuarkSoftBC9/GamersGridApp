using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.ViewModels
{
    public class NewTeamViewModel
    {
        public Team Team { get; set; }
        public IQueryable<Game> Games { get; set; }

        public NewTeamViewModel(Team team, IQueryable<Game> games)
        {
            Team = team;
            Games = games;
        }
        public NewTeamViewModel()
        { }
    }
}
using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGridApp.Core.Repositories
{
    public interface ITeamRepository
    {
        void AddTeam(Team team);
        Team GetTeam(int id);
        Team GetTeamByName(string name);
    }
}

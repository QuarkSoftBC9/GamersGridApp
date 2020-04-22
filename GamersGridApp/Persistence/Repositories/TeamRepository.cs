using GamersGridApp.Core.Models;
using GamersGridApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Team GetTeam(int id)
        {
            return _context.Teams.Where(t => t.ID == id)
                .Include(tu => tu.TeamUsers.Select(u => u.User))
                .Include(a => a.Admin)
                .Include(g => g.Game)
                .SingleOrDefault();
        }
        public void AddTeam(Team team)
        {
            _context.Teams.Add(team);
        }
        public Team GetTeamByName(string name)
        {
            return _context.Teams
                .SingleOrDefault(t => t.Name == name);
        }
    }
}
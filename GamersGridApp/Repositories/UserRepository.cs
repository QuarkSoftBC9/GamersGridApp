using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public User GetUser(string name)
        {
            return _context.GamersGridUsers
                .SingleOrDefault(u => u.NickName.Contains(name));

        }
    }
}
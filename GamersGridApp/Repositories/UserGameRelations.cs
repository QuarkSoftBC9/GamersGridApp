using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Repositories
{
    public class UserGameRelations
    {
        private readonly ApplicationDbContext _context;

        public UserGameRelations(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
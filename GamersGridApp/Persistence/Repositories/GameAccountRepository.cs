using GamersGridApp.Core.Models;
using GamersGridApp.Core.Repositories;
using GamersGridApp.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.Repositories
{
    public class GameAccountRepository : IGameAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public GameAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public GameAccount GetGameAccByNameAndRegion(string nickName, string region)
        {
            return _context.GameAccounts
                .Where(la => la.NickName == nickName && la.AccountRegions == region)
                .SingleOrDefault();
        }

    }
}
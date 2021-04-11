using GamersGrid.BLL.Repositories.Abstractions;
using GamersGrid.DAL;
using GamersGrid.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.BLL.Repositories
{
    public class GameAccountRepository : Repository<GameAccount>
    {
        public GameAccountRepository(ApplicationDbContext db) : base(db)
        {
        }

        public async Task<GameAccount> GetGameAccByNameAndRegion(string nickName, string region)
        {
            return await _db.GameAccounts
                .Where(la => la.NickName == nickName && la.AccountRegions == region)
                .SingleOrDefaultAsync();
        }
    }
}

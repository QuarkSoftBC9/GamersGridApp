using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models.Identity
{
    public class CustomUserStore : UserStore<GGuser, CustomRole, ApplicationDbContext, int>
    {
        public CustomUserStore(ApplicationDbContext context, IdentityErrorDescriber describer = null)
        : base(context, describer)
        {
        }
    }
}

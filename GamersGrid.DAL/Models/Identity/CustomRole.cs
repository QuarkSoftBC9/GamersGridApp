using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models.Identity
{
    public class CustomRole : IdentityRole<int>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }
}

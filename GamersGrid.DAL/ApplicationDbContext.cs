using GamersGrid.DAL.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL
{
    public class ApplicationDbContext : IdentityDbContext<GGuser, CustomRole, int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<GGuser>().ToTable("Users");
            builder.Entity<CustomRole>().ToTable("Roles");

        }
    }
}

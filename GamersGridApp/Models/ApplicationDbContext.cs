using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> GamersGridUsers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGameRelations { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Video> Videos { get; set; }


        public ApplicationDbContext()
            : base("GamersGridDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


  
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithMany(u => u.Followees)
                .Map(t => t.MapLeftKey("UserID")
                .MapRightKey("FollowerID")
                .ToTable("Followers"));



        }
    }
}
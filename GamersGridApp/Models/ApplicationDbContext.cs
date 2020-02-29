using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GamersGridApp.Models;

namespace GamersGridApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<User> GamersGridUsers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<UserGame> UserGameRelations { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Follow> Follows { get; set; }


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

            //schema builder for "Follows" table
            modelBuilder.Entity<User>()
                .HasMany(u => u.Followers)
                .WithRequired(f => f.User)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<User>()
                .HasMany(u => u.FollowedBy)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Follow>()
                .HasIndex(k => new { k.UserId, k.FollowerId }).IsUnique();

            //modelBuilder.Entity<Follower>()
            // .HasKey(k => new { k.UserId, k.FollowerId });

            //.Map(cs =>
            //{
            //    cs.MapLeftKey("StudentRefId");
            //    cs.MapRightKey("CourseRefId");
            //    cs.ToTable("StudentCourse");
            //});
            //modelBuilder.Entity<Follower>()
            //    .HasOne(u => u.User)
            //    .WithMany()
            //    .HasForeignKey(e => e.UserId);

            //modelBuilder.Entity<Follower>()
            //    .HasOne(e => e.)
            //    .WithMany(e => e.RelatedFrom)
            //    .HasForeignKey(e => e.ToId);


        }
    }
}
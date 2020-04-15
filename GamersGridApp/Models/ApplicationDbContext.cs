using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using GamersGridApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using GamersGridApp.Perstistence.EntityConfigurations;

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
        public DbSet<GameAccount> GameAccounts { get; set; }
        public DbSet<GameAccountStats> GameAccountStats { get; set; }

        public DbSet<MessageChatUser> MessageChatUsers { get; set; }

        public DbSet<MessageChat> MessageChats { get; set; }

        public DbSet<Message> Messages { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<UserPosting> UserPostings { get; set; }

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

            //modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new FollowConfiguration());
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new GameAccountConfiguration());
            modelBuilder.Configurations.Add(new GameAccountStatsConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
            modelBuilder.Configurations.Add(new MessageChatConfiguration());
            modelBuilder.Configurations.Add(new MessageChatUserConfiguration());
            modelBuilder.Configurations.Add(new NotificationConfiguration());
            modelBuilder.Configurations.Add(new PhotoConfiguration());
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new UserGameConfiguration());
            modelBuilder.Configurations.Add(new UserNotificationConfiguration());
            modelBuilder.Configurations.Add(new UserPostingConfiguration());
            modelBuilder.Configurations.Add(new VideoConfiguration());


            //schema builder for "Follows" table
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Followers)
            //    .WithRequired(f => f.User)
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Followees)
            //    .WithRequired(f => f.Follower)
            //    .WillCascadeOnDelete(false);
            //modelBuilder.Entity<Follow>()
            //    .HasIndex(k => new { k.UserId, k.FollowerId }).IsUnique();

            //modelBuilder.Entity<UserGame>()
            //    .HasIndex(ug => ug.GameAccountId).IsUnique();

            //modelBuilder.Entity<GameAccount>().Property(m => m.Id)
            // .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            //modelBuilder.Entity<UserGame>()
            //    .HasIndex(k => new { k.GameID, k.UserId }).IsUnique();

            //modelBuilder.Entity<User>()
            //    .HasMany(m => m.MessageChatUsers)
            //    .WithRequired(m => m.User);
            //modelBuilder.Entity<MessageChat>()
            //    .HasMany(m => m.MessageChatUsers)
            //    .WithRequired(m => m.Chat);

            //modelBuilder.Entity<UserPosting>()
            //    .HasRequired(u => u.Poster)
            //    .WithMany()
            //    .HasForeignKey(u => u.PosterId)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UserPosting>()
            //  .HasRequired(u => u.Owner)
            //  .WithMany()
            //  .HasForeignKey(u => u.OwnerId)
            //  .WillCascadeOnDelete(false);


            //modelBuilder.Entity<UserPosting>()
            // .HasMany(u => u.user)
            // .WithRequired(f => f.User)
            // .WillCascadeOnDelete(false);





            //modelBuilder.Entity<Notification>()
            //  .Property(f => f.TimeStamp)
            //  .HasColumnType("datetime");



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
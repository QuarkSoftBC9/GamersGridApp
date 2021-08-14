﻿using GamersGrid.DAL.Models;
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

        public DbSet<UsersGamesRelation> UsersGames { get; set; }
        public DbSet<VideoGame> Games { get; set; }
        public DbSet<GameAccount> GameAccounts { get; set; }
        public DbSet<GameAccountStats> GameAccountsStats { get; set; }
        public DbSet<FollowRelation> FollowRelations { get; set; }
        public DbSet<UsersGamesRelation> UsersGamesRelations { get; set; }
        public DbSet<ChatGroup> ChatGroups { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserChatGroup> UserChatGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<GGuser>().ToTable("Users");
            builder.Entity<GGuser>().HasIndex(u => u.Email).IsUnique();
            builder.Entity<GGuser>().HasIndex(u => u.NickName).IsUnique();


            builder.Entity<GGuser>()
                .HasMany(u => u.Followers)
                .WithOne(f => f.User)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


            builder.Entity<GGuser>()
                .HasMany(user => user.Followees)
                .WithOne(fr => fr.Follower)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<GGuser>()
                .HasMany<UserChatGroup>(u => u.RelatedChatGroups)
                .WithOne(ucg => ucg.User)
                .IsRequired()
                .HasForeignKey(ucg=>ucg.UserId);

            builder.Entity<FollowRelation>().ToTable("FollowRelations");
            builder.Entity<FollowRelation>()
                .HasIndex(fr => new { fr.UserId, fr.FollowerId })
                .IsUnique();


            builder.Entity<CustomRole>().ToTable("Roles");

            builder.Entity<UsersGamesRelation>().ToTable("UsersGamesRelations");
            builder.Entity<UsersGamesRelation>()
                .HasIndex(usr => new { usr.UserId, usr.GameId })
                .IsUnique();

            builder.Entity<VideoGame>().ToTable("VideoGames");

            builder.Entity<GameAccount>().ToTable("GameAccounts");
            builder.Entity<GameAccount>()
                .HasOne(ga => ga.Statistics)
                .WithOne(gas => gas.GameAccount)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<GameAccountStats>().ToTable("GameAccountStats");


            builder.Entity<ChatGroup>().ToTable("ChatGroups");
            builder.Entity<ChatGroup>()
                .HasMany(cg => cg.Messages)
                .WithOne(m => m.Group);

            builder.Entity<ChatGroup>()
                .HasMany<UserChatGroup>(cg=>cg.UserChatGroups)
                .WithOne(ucg => ucg.Group)
                .IsRequired()
                .HasForeignKey(ucg => ucg.GroupId);

            builder.Entity<Message>().ToTable("Messages");
            builder.Entity<Message>()
                .HasOne<GGuser>(m=>m.User)
                .WithMany(u => u.Messages)
                .IsRequired()
                .HasForeignKey(m => m.UserId);

            builder.Entity<Message>()
                .HasOne<ChatGroup>(m => m.Group)
                 .WithMany(cg => cg.Messages)
                .IsRequired()
                  .HasForeignKey(m => m.GroupId);

            builder.Entity<UserChatGroup>().ToTable("UserChatGroups");
            builder.Entity<UserChatGroup>()
                .HasIndex(ucg => new { ucg.UserId, ucg.GroupId })
                .IsUnique();
            //builder.Entity<UserChatGroup>()
            //    .HasOne<GGuser>(ucg => ucg.User);

            //builder.Entity<UserChatGroup>()
            //    .HasOne<ChatGroup>(ucg => ucg.Group);
            //.WithMany()
            //.IsRequired()
            //.HasForeignKey(ucg => ucg.GroupId);


        }
    }
}

using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.EntityConfigurations
{
    public class UserConfiguration :  EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(u => u.FirstName)
              .HasMaxLength(50);
            Property(u => u.LastName)
              .HasMaxLength(50);
            Property(u => u.NickName)
              .HasMaxLength(50);
            Property(u => u.Description)
              .HasMaxLength(255);
            Property(u => u.Country)
              .HasMaxLength(50);
            Property(u => u.City)
              .HasMaxLength(50);




            HasMany(u => u.Followers)
                .WithRequired(f => f.User)
                .WillCascadeOnDelete(false);

              HasMany(u => u.Followees)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

              HasMany(m => m.MessageChatUsers)
                .WithRequired(m => m.User);
        }
    }
}
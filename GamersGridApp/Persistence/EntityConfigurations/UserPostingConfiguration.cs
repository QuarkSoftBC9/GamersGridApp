
using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.EntityConfigurations
{
    public class UserPostingConfiguration : EntityTypeConfiguration<UserPosting>
    {
        public UserPostingConfiguration()
        {
              HasRequired(u => u.Poster)
                .WithMany()
                .HasForeignKey(u => u.PosterId)
                .WillCascadeOnDelete(false);
            
            HasRequired(u => u.Owner)
              .WithMany()
              .HasForeignKey(u => u.OwnerId)
              .WillCascadeOnDelete(false);

        }
    }
}
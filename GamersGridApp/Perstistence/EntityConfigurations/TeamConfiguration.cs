using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Perstistence.EntityConfigurations
{
    public class TeamConfiguration : EntityTypeConfiguration<Team>
    {
        public TeamConfiguration()
        {
            Property(t => t.Name)
              .HasMaxLength(50);

            HasMany(t => t.TeamUsers)
                .WithRequired(tu => tu.Team)
                .WillCascadeOnDelete(false);

            HasRequired(t => t.Admin)
               .WithMany(u => u.Teams)
               .WillCascadeOnDelete(false);

            HasRequired(t => t.Game)
                .WithMany(g => g.Teams)
                .WillCascadeOnDelete(false);

           


        }
    }
}
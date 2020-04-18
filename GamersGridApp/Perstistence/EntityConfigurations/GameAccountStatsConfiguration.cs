using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Perstistence.EntityConfigurations
{
    public class GameAccountStatsConfiguration : EntityTypeConfiguration<GameAccountStats>
    {
        public GameAccountStatsConfiguration()
        {
            HasKey(g => g.Id);

            //HasRequired(g => g.GameAccount)
            //    .WithMany()
            //    .HasForeignKey(g=>g.Id)
            //    .WillCascadeOnDelete(false);

            //HasOptional(g => g.GameAccount)
            //    .WithMany()
            //    .HasForeignKey(g => g.Id);


        }
    }
}
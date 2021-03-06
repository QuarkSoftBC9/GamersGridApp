﻿using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.EntityConfigurations
{
    public class GameAccountConfiguration : EntityTypeConfiguration<GameAccount>
    {
        public GameAccountConfiguration()
        {

            //HasRequired(x => x.UserGame)
            //   .WithMany()
            //   .HasForeignKey(x => x.Id);

            Property(m => m.Id)
             .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            HasOptional(gs => gs.GameAccountStats)
                .WithRequired(ga => ga.GameAccount);
        }
    }
}
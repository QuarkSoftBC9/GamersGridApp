﻿using GamersGridApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Persistence.EntityConfigurations
{
    public class UserGameConfiguration : EntityTypeConfiguration<UserGame>
    {
        public UserGameConfiguration()
        {
            HasIndex(k => new { k.GameID, k.UserId }).IsUnique();

            HasOptional(ga => ga.GameAccount)
                .WithRequired(ug => ug.UserGame);
        }
    }
}
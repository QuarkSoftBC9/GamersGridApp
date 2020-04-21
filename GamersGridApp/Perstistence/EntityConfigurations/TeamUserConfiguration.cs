using GamersGridApp.Dtos.ApiAcountsDtos;
using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace GamersGridApp.Perstistence.EntityConfigurations
{
    public class TeamUserConfiguration: EntityTypeConfiguration<TeamUser>
    {
        public TeamUserConfiguration()
        {
            HasKey(k => new { k.TeamID, k.UserID });


            Property(tu => tu.Role)
                .HasMaxLength(50);

        }
   

    }
}
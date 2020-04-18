using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.ApiAcountsDtos
{
    public class FollowsDto
    {
        public int FolloweeId { get; set; }
        public int FollowerId { get; set; }
    }
}
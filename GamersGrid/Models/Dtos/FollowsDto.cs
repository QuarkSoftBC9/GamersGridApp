using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamersGrid.Models.Dtos
{
    public class FollowsDto
    {
        public int FolloweeId { get; set; }
        public int FollowerId { get; set; }
    }
}

using GamersGrid.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public class FollowRelation
    {
        public int Id { get; set; }

        //[Required]
        public int UserId { get; set; }

        //[Required]
        public int FollowerId { get; set; }

        public GGuser User { get; set; }

        public GGuser Follower { get; set; }
        public DateTime TimeStamp { get; set; }

        protected FollowRelation()
        { }

        public FollowRelation(int userId, int followerId)
        {
            UserId = userId;
            FollowerId = followerId;
            TimeStamp = DateTime.Now;
        }
    }
}

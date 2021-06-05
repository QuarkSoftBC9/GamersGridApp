using GamersGrid.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public class UserChatGroup
    {
        public int Id { get; set; }
        public virtual GGuser User { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual ChatGroup Group { get; set; }
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public string Name { get; set; }
    }
}


using GamersGrid.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public class Message
    {
        public int Id { get; set; }
        public virtual GGuser User { get; set; }
        public int UserId { get; set; }
        public virtual ChatGroup Group { get; set; }
        public int GroupId { get; set; }
        public string Value { get; set; }
        public DateTime Time { get; set; }
    }
}

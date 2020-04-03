using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class UserPosting
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int PosterId { get; set; }
        public User Owner { get; set; }
        public User Poster { get; set; }
        public DateTime PostingDate { get; set; }
        public String PostingMessage { get; set; }
    }
}
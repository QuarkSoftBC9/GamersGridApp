using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Core.Models
{
    public class Photo
    {
        public int ID { get; set; }
        public int? UserId { get; set; }
        public int? GameId { get; set; }
        public string Path { get; set; }
        public DateTime? DateUploaded { get; set; }

        public Photo()
        {
            DateUploaded = DateTime.Now;
        }
    }
}
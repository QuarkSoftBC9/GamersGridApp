﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public User User { get; set; }
        public string MessageString { get; set; }


        public DateTime? Time
        {
            get; set;
        }

        
    }
}
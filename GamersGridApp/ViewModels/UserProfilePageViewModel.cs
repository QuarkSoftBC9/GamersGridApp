using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class UserProfilePageViewModel
    {
        public User User { get; set; }
        public bool IsCurrent { get; set; }
    }
}
using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class ProfileGameViewModel
    {
        public Game Game { get; set; }
        public int UsersFocusing { get; set; }
    }
}
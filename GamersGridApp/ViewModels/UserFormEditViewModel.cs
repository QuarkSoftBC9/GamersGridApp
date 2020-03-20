using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class UserFormEditViewModel
    {
       
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        
    }
}
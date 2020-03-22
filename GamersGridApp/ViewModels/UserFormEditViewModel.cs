using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class UserFormEditViewModel
    {
       
        public int ID { get; private  set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string NickName { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public UserFormEditViewModel(User user)
        {
            if (user.ID == 0)
                throw new ArgumentNullException("User id is 0");
            ID = user.ID;
            FirstName = user.FirstName;
            LastName = user.LastName;
            NickName = user.NickName;
            Description = user.Description;
            Country = user.Country;
            City = user.City;
        }
        protected UserFormEditViewModel() { }
    }
}
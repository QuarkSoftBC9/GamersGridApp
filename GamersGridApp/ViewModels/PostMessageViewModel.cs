using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class PostMessageViewModel
    {
        public int OwnerId { get; set; }
        public int PosterId { get; set; }
        public User Owner { get; set; }
        public User Poster { get; set; }
        public DateTime PostingDate { get; set; }
        public String PostingMessage { get; set; }
        public List<ApplicationUser> OtherUsers { get; set; }

        public PostMessageViewModel()
        {
            OtherUsers = new List<ApplicationUser>();
        }
        public PostMessageViewModel(List<ApplicationUser> others)
        {
            OtherUsers = others;
        }


    }
}
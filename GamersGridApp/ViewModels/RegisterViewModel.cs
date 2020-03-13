using GamersGridApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GamersGridApp.ViewModels
{
    public class RegisterViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }


        private bool dota;

        public bool Dota
        {
            get 
            {
                if (dota)
                {
                    FavouriteGames.Add(new Game()
                    {
                        Title = "Dota"
                    });
                }
                return dota; 
            }
            set { dota = value; }
        }

        private bool lol;

        public bool Lol
        {
            get 
            {
                if (lol)
                {
                    FavouriteGames.Add(new Game()
                    {
                        Title = "Lol"
                    });
                }
                return lol;

            }
            set { lol = value; }
        }
        private bool cs;

        public bool Cs
        {
            get
            {
                if (cs)
                {
                    FavouriteGames.Add(new Game()
                    {
                        Title = "CS"
                    });
                }
                return cs; 
            }
            set { cs = value; }
        }

        public string NickName { get; set; }

        [Required]
        [StringLength(16,MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Avatar { get; set; }

        public List<Game> FavouriteGames { get; set; }
    }
}
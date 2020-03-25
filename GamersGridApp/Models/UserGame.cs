using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public class UserGame
    {

        public int Id { get; set; }

        //[Key]
        //[Column(Order = 1)]
        public int UserId { get; set; }
        // [Key]
        //[Column(Order = 2)]
        public int GameID { get; set; }

        public User User { get; set; }
        public Game Game { get; set; }

        public GameAccount GameAccount { get; set; }

        public int GameAccountId { get; set; }

        //public  MyProperty { get; set; }

        public bool IsFavoriteGame { get; set; }

        public UserGame(Game game,int userid,bool favorite,GameAccount gameAccount)
        {
            Game = game;
            UserId = userid;
            IsFavoriteGame = favorite;
            GameAccount = gameAccount;
        }

    }
}
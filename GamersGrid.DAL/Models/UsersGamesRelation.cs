using GamersGrid.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public class UsersGamesRelation
    {
        public int Id { get; set; }

        //[Key]
        //[Column(Order = 1)]
        public int UserId { get; set; }
        public GGuser User { get; set; }
        // [Key]
        //[Column(Order = 2)]
        public int GameId { get; set; }

        public VideoGame Game { get; set; }

        public VideoGameAccount GameAccount { get; set; }

        //public int GameAccountId { get; set; }


        public bool IsFavoriteGame { get; set; }

        //constructor needed just for testing purposes of api
        public UsersGamesRelation()
        {  }

        public UsersGamesRelation(int userId,int gameId)
        {
            UserId = userId;
            GameId = gameId;
            IsFavoriteGame = true;
        }



        //public UsersGamesRelation(int gameID, int userid, GameAccount gameAccount)
        //{
        //    GameID = gameID;
        //    UserId = userid;
        //    GameAccount = gameAccount;
        //}
        //public UsersGamesRelation(Game game, int userid, bool favorite, GameAccount gameAccount)
        //{
        //    Game = game;
        //    UserId = userid;
        //    IsFavoriteGame = favorite;
        //    GameAccount = gameAccount;
        //}

        //public void AddNewAccount()
        //{
        //    if (GameAccount == null)
        //        CreateNewAccount();
        //    UpdateAccount();
        //}
        //public void CreateNewAccount()
        //{

        //}
        //public void UpdateAccount()
        //{

        //}
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public bool IsFavoriteGame { get; set; }

        //constructor needed just for testing purposes of api
        public UserGame()
        { }
        //Registration constructor
        public UserGame(Game game, int userid, bool favorite)
        {
            Game = game;
            UserId = userid;
            IsFavoriteGame = favorite;
        }
        //typical constructor
        public UserGame(int userId, int gameId)
        {
            UserId = userId;
            GameID = gameId;
        }
        //new gameAccount for League of Legends
        public void NewGameAccount(string nickName, string identifier1, string identifier2, string region)
        {
            if (GameAccount == null)
                GameAccount = new GameAccount(nickName, identifier1, identifier2, region);
            else
                GameAccount.UpdateAccount(nickName, identifier1, identifier2, region);
        }
        //new gameAccount for Dota2 and Overwatch
        public void NewGameAccount(string nickName, string identifier1, string region)
        {
            if (GameAccount == null)
                GameAccount = new GameAccount(nickName, identifier1, region);
            else
                GameAccount.UpdateAccount(nickName, identifier1, region);
        }

        public static UserGame CreateNewRelationWithAccountDota(int gameId, int userId, string nickname, string uniqueId, int wins, int loses, string kda)
        {
            var userGame = new UserGame(userId, gameId);
            userGame.GameAccount = new GameAccount(nickname, uniqueId, null);
            userGame.GameAccount.GameAccountStats = new GameAccountStats(userGame.GameAccount, null, wins, loses, kda);

            return userGame;
        }
        

        


        //public UserGame(int gameID, int userid, GameAccount gameAccount)
        //{
        //    GameID = gameID;
        //    UserId = userid;
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
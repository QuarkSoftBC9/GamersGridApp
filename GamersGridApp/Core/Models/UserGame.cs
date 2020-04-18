
using GamersGridApp.Core.ApiAcountsDtos;
using GamersGridApp.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace GamersGridApp.Core.Models
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

        public static UserGame CreateNewRelationWithAccountDota(int userId,DotaDto dotaDto,DotaWinsLosesDto wlDto, List<DotaMatchDto> matchesDto )
        {
            const int dotaId = 2;
            var kda = Convert.ToString(ExtraMethods.CalculateKda(matchesDto));
            var userGame = new UserGame(userId, dotaId);
            userGame.GameAccount = new GameAccount(dotaDto.profile.personaname,Convert.ToString(dotaDto.profile.account_id),dotaDto.profile.steamid, dotaDto.profile.loccountrycode);
            userGame.GameAccount.GameAccountStats = new GameAccountStats(userGame.GameAccount, Convert.ToString(dotaDto.competitive_rank),wlDto.win, wlDto.lose, kda);

            return userGame;
        }
        public static UserGame CreateNewRelationWithAccountOverWatch(int userId,string battletag,string region, OverWatchCompleteDto completeProfileDto)
        {
            const int overwatchId = 3;
            string kda = "0";
            if (completeProfileDto.competitiveStats != null)
            {
                kda = Convert.ToString(ExtraMethods.CalculateKda(
                   completeProfileDto.competitiveStats.careerStats.allHeroes.average.deathsAvgPer10Min,
                   completeProfileDto.competitiveStats.careerStats.allHeroes.average.eliminationsAvgPer10Min));
            }

            var userGame = new UserGame(userId, overwatchId);
            userGame.GameAccount = new GameAccount(completeProfileDto.name,battletag,region );
            userGame.GameAccount.GameAccountStats = new GameAccountStats(userGame.GameAccount, Convert.ToString(completeProfileDto.rating), completeProfileDto.gamesWon, 0, kda);

            return userGame;
        }




    }
}
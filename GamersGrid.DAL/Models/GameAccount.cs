using GamersGrid.DAL.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public class GameAccount
    {
        //[Key]
        //[ForeignKey("Statistics")]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public GGuser User { get; set; }


        [ForeignKey("Game")]
        public int GameId { get; set; }
        public VideoGame Game { get; set; }

        public GameAccountStats Statistics { get; set; }

        public string NickName { get; set; }
        public string AccountIdentifier { get; set; }
        public string AccountIdentifier2 { get; set; }
        public string AccountRegions { get; private set; }


        public GameAccount()
        { }

        //constructor for Dota2 and Overwatch
        public GameAccount(string nickname, string identifier, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }

        //constructor for Leage of Legends
        public GameAccount(string nickname, string identifier, string identifier2, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountIdentifier2 = identifier2;
            AccountRegions = region;
        }

        //Update stats for Overwatch
        public void UpdateAccount(string nickName, string battleTag, string region)
        {
            int nickNameSpecialCharLocation = nickName.IndexOf("#");
            NickName = nickName.Substring(0, nickNameSpecialCharLocation);
            AccountIdentifier = battleTag;
            AccountRegions = region;
        }

        //Update stats for LeagueOfLegends
        public void UpdateAccount(string nickName, string identifier1, string identifier2, string region)
        {
            NickName = nickName;
            AccountIdentifier = identifier1;
            AccountIdentifier2 = identifier2;
            AccountRegions = region;
        }
        //Update stats for Dota2 
        public void UpdateAccountDota(string steamId, string accountId, string peronName,string loccountryCode)
        {
            AccountIdentifier = steamId;
            AccountIdentifier2 = accountId;
            NickName = peronName;
            AccountRegions = loccountryCode;
        }

    }
}

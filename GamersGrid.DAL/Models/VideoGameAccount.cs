using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public class VideoGameAccount
    {
        [Key]
        [ForeignKey("UserGameRelationId")]
        public int Id { get; set; }
        public virtual UsersGamesRelation UserGameRelationId { get; set; }
        public string NickName { get; set; }
        public string AccountIdentifier { get; set; }
        public string AccountIdentifier2 { get; set; }
        public string AccountRegions { get; private set; }
        public VideoGameAccount()
        { }
        public VideoGameAccount(string nickname, string identifier, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }
        public VideoGameAccount(string nickname, string identifier, string identifier2, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountIdentifier2 = identifier2;
            AccountRegions = region;
        }
        public void UpdateAccount(string nickname, string identifier, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountRegions = region;
        }

        public void UpdateLOLAccount(string nickname, string identifier, string identifier2, string region)
        {
            NickName = nickname;
            AccountIdentifier = identifier;
            AccountIdentifier2 = identifier2;
            AccountRegions = region;
        }
    }
}

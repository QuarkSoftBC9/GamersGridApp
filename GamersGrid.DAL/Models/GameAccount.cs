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



    }
}

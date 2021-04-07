using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public class GameAccountStats
    {
        [Key]
        [ForeignKey("GameAccount")]
        public int GameAccountId { get; set; }
        public GameAccount GameAccount { get; set; }

        public string KDA { get; set; }
        public string Rank { get; set; }
        public int Wins { get; set; }

        public int Losses { get; set; }
        public int HoursPlayed { get; set; }

    }
}

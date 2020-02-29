using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Dtos
{
    public enum Genre
    {
        FPS, RTS, Cards
    }
    public class GameDto
    {
        //public int ID { get; set; }
        public string Title { get; set; }
        //public string Description { get; set; }
        //public DateTime ReleaseDate { get; set; }
        //public Genre Type { get; set; }
    }
}
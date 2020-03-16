using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GamersGridApp.Models
{
    public enum Genre
    {
        FPS, RTS, Cards
    }
    public class Game
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Type { get; set; }
        public string SearchIconPath { get; set; }
        
            
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamersGrid.DAL.Models
{
    public enum GameGenre
    {
        FPS, RTS, Cards
    }
    public class VideoGame
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public GameGenre Type { get; set; }
        public string SearchIconPath { get; set; }

        //public ICollection<Photo> Photos { get; set; }

        public VideoGame()
        {
            //Photos = new List<Photo>() { };
        }
        public VideoGame(string title)
        {
            Title = title;
        }




        public static VideoGame GetGameInstance(string gameTitle)
        {
            switch (gameTitle)
            {
                case "Dota":
                    return GetDotaGameInstance();

                case "Overwatch":
                    return GetOverwatchGameInstance();

                default:
                    return GetLeagueOfLegendsGameInstance();
            }
        }

        private static VideoGame GetDotaGameInstance()
         => new VideoGame
         {
             Title = "Dota",
             Description = "Dota 2 is a multiplayer online battle arena video game developed and published by Valve. The game is a sequel to Defense of the Ancients, which was a community-created mod for Blizzard Entertainments Warcraft III: Reign of Chaos and its expansion pack, The Frozen Throne.",
             ReleaseDate = new DateTime(2013,7,9),
             Type = GameGenre.RTS,
             SearchIconPath = string.Empty
         };

        private static VideoGame GetOverwatchGameInstance()
         => new VideoGame
         {
             Title = "Overwatch",
             Description = "Overwatch is a team-based multiplayer first-person shooter developed and published by Blizzard Entertainment. Described as a hero shooter, Overwatch assigns players into two teams of six, with each player selecting from a roster of over 30 characters, known as heroes, each with a unique style of play that is divided into three general roles that fit their purpose. Players on a team work together to secure and defend control points on a map or escort a payload across the map in a limited amount of time. Players gain cosmetic rewards that do not affect gameplay, such as character skins and victory poses, as they play the game",
             ReleaseDate = new DateTime(2016, 5, 24),
             Type = GameGenre.RTS,
             SearchIconPath = string.Empty
         };
        private static VideoGame GetLeagueOfLegendsGameInstance()
         => new VideoGame
         {
             Title = "League of Legends",
             Description = "League of Legends (LoL) is a multiplayer online battle arena video game developed and published by Riot Games for Microsoft Windows and macOS. In League of Legends, players assume the role of a champion with unique abilities and battle against a team of other player- or computer-controlled champions. The goal is usually to destroy the opposing team's Nexus, a structure that lies at the heart of a base protected by defensive structures, although other distinct game modes exist as well with varying objectives, rules, and maps. Each League of Legends match is discrete, with all champions starting off relatively weak but increasing in strength by accumulating items and experience over the course of the game. Champions span a variety of roles and blend a variety of fantasy tropes, such as sword and sorcery, steampunk, and Lovecraftian horror. Although the discrete nature of each match prohibits an overarching narrative in-game, the various champions make up a large and ever-evolving fictional universe developed by Riot Games through short stories, comics, cinematics, and books",
             ReleaseDate = new DateTime(2009,10, 27),
             Type = GameGenre.RTS,
             SearchIconPath = string.Empty
         };

    }
}

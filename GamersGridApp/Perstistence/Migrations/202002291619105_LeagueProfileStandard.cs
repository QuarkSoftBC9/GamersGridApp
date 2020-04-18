namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeagueProfileStandard : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT [dbo].[Games] ( [Title], [ReleaseDate], [Type], [Description]) VALUES ( N'League Of Legends', CAST(N'2009-10-27T00:00:00.000' AS DateTime), 1, N'League of Legends (LoL) is a multiplayer online battle arena video game developed and published by Riot Games for Microsoft Windows and macOS. In League of Legends, players assume the role of a champion with unique abilities and battle against a team of other player- or computer-controlled champions. The goal is usually to destroy the opposing team''s Nexus, a structure that lies at the heart of a base protected by defensive structures, although other distinct game modes exist as well with varying objectives, rules, and maps. Each League of Legends match is discrete, with all champions starting off relatively weak but increasing in strength by accumulating items and experience over the course of the game. Champions span a variety of roles and blend a variety of fantasy tropes, such as sword and sorcery, steampunk, and Lovecraftian horror. Although the discrete nature of each match prohibits an overarching narrative in-game, the various champions make up a large and ever-evolving fictional universe developed by Riot Games through short stories, comics, cinematics, and books')" + "SET IDENTITY_INSERT[dbo].[Games] OFF");
        }
        
        public override void Down()
        {
        }
    }
}

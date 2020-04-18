namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingGameStatsGameAcc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        NickName = c.String(),
                        AccountIdentifier = c.String(),
                        AccountIdentifier2 = c.String(),
                        AccountRegions = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserGames", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.GameAccountStats",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        KDA = c.String(),
                        Rank = c.String(),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        HoursPlayed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameAccounts", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameAccounts", "Id", "dbo.UserGames");
            DropForeignKey("dbo.GameAccountStats", "Id", "dbo.GameAccounts");
            DropIndex("dbo.GameAccountStats", new[] { "Id" });
            DropIndex("dbo.GameAccounts", new[] { "Id" });
            DropTable("dbo.GameAccountStats");
            DropTable("dbo.GameAccounts");
        }
    }
}

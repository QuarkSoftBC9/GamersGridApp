namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropingGameAccGameStatsColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameAccountStats", "Id", "dbo.GameAccounts");
            DropForeignKey("dbo.GameAccounts", "Id", "dbo.UserGames");
            DropIndex("dbo.GameAccounts", new[] { "Id" });
            DropIndex("dbo.GameAccountStats", new[] { "Id" });
            DropTable("dbo.GameAccounts");
            DropTable("dbo.GameAccountStats");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.GameAccountStats", "Id");
            CreateIndex("dbo.GameAccounts", "Id");
            AddForeignKey("dbo.GameAccounts", "Id", "dbo.UserGames", "Id");
            AddForeignKey("dbo.GameAccountStats", "Id", "dbo.GameAccounts", "Id");
        }
    }
}

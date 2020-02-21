namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGameRelationAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGames",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        GameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GameID })
                .ForeignKey("dbo.Games", t => t.GameID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GameID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGames", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserGames", "GameID", "dbo.Games");
            DropIndex("dbo.UserGames", new[] { "GameID" });
            DropIndex("dbo.UserGames", new[] { "UserId" });
            DropTable("dbo.UserGames");
        }
    }
}

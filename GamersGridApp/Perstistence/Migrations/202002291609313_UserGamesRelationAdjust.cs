namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserGamesRelationAdjust : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.UserGames", new[] { "UserId" });
            DropIndex("dbo.UserGames", new[] { "GameID" });
            DropPrimaryKey("dbo.UserGames");
            AddColumn("dbo.UserGames", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserGames", "Id");
            CreateIndex("dbo.UserGames", new[] { "GameID", "UserId" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.UserGames", new[] { "GameID", "UserId" });
            DropPrimaryKey("dbo.UserGames");
            DropColumn("dbo.UserGames", "Id");
            AddPrimaryKey("dbo.UserGames", new[] { "UserId", "GameID" });
            CreateIndex("dbo.UserGames", "GameID");
            CreateIndex("dbo.UserGames", "UserId");
        }
    }
}

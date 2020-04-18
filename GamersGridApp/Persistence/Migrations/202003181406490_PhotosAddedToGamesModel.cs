namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotosAddedToGamesModel : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Photos", "GameId");
            AddForeignKey("dbo.Photos", "GameId", "dbo.Games", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "GameId", "dbo.Games");
            DropIndex("dbo.Photos", new[] { "GameId" });
        }
    }
}

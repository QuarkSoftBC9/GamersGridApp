namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomethingToAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserGames", "IsFavoriteGame", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserGames", "IsFavoriteGame");
        }
    }
}

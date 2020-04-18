namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CuttingGameAccUserGameRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGames", "GameAccountId", "dbo.GameAccounts");
            DropIndex("dbo.UserGames", new[] { "GameAccountId" });
            DropColumn("dbo.UserGames", "GameAccountId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserGames", "GameAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserGames", "GameAccountId");
            AddForeignKey("dbo.UserGames", "GameAccountId", "dbo.GameAccounts", "Id", cascadeDelete: true);
        }
    }
}

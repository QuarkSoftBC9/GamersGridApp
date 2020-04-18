namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CuttingGameAccGameStatsRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameAccounts", "GameAccountStats_Id", "dbo.GameAccountStats");
            DropIndex("dbo.GameAccounts", new[] { "GameAccountStats_Id" });
            DropColumn("dbo.GameAccounts", "GameAccountStats_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GameAccounts", "GameAccountStats_Id", c => c.Int());
            CreateIndex("dbo.GameAccounts", "GameAccountStats_Id");
            AddForeignKey("dbo.GameAccounts", "GameAccountStats_Id", "dbo.GameAccountStats", "Id");
        }
    }
}

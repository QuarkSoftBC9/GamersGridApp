namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removingGameStatsGameAccRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.GameAccountStats", "Id", "dbo.GameAccounts");
            DropIndex("dbo.UserGames", new[] { "GameAccountId" });
            DropIndex("dbo.GameAccountStats", new[] { "Id" });
            DropPrimaryKey("dbo.GameAccountStats");
            AddColumn("dbo.GameAccounts", "GameAccountStats_Id", c => c.Int());
            AlterColumn("dbo.GameAccountStats", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GameAccountStats", "Id");
            CreateIndex("dbo.UserGames", "GameAccountId");
            CreateIndex("dbo.GameAccounts", "GameAccountStats_Id");
            AddForeignKey("dbo.GameAccounts", "GameAccountStats_Id", "dbo.GameAccountStats", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameAccounts", "GameAccountStats_Id", "dbo.GameAccountStats");
            DropIndex("dbo.GameAccounts", new[] { "GameAccountStats_Id" });
            DropIndex("dbo.UserGames", new[] { "GameAccountId" });
            DropPrimaryKey("dbo.GameAccountStats");
            AlterColumn("dbo.GameAccountStats", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.GameAccounts", "GameAccountStats_Id");
            AddPrimaryKey("dbo.GameAccountStats", "Id");
            CreateIndex("dbo.GameAccountStats", "Id");
            CreateIndex("dbo.UserGames", "GameAccountId", unique: true);
            AddForeignKey("dbo.GameAccountStats", "Id", "dbo.GameAccounts", "Id");
        }
    }
}

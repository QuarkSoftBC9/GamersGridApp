namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingGameAccGameStatsRelationship : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GameAccountStats");
            AlterColumn("dbo.GameAccountStats", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.GameAccountStats", "Id");
            CreateIndex("dbo.GameAccountStats", "Id");
            AddForeignKey("dbo.GameAccountStats", "Id", "dbo.GameAccounts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameAccountStats", "Id", "dbo.GameAccounts");
            DropIndex("dbo.GameAccountStats", new[] { "Id" });
            DropPrimaryKey("dbo.GameAccountStats");
            AlterColumn("dbo.GameAccountStats", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GameAccountStats", "Id");
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creating1to1relationshipUserGame_GamaeAcc : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.GameAccounts");
            AlterColumn("dbo.GameAccounts", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.GameAccounts", "Id");
            CreateIndex("dbo.GameAccounts", "Id");
            AddForeignKey("dbo.GameAccounts", "Id", "dbo.UserGames", "Id");
            Sql("SET IDENTITY_INSERT dbo.GameAccounts ON");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameAccounts", "Id", "dbo.UserGames");
            DropIndex("dbo.GameAccounts", new[] { "Id" });
            DropPrimaryKey("dbo.GameAccounts");
            AlterColumn("dbo.GameAccounts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.GameAccounts", "Id");
        }
    }
}

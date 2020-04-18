namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameAccountTableAndRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "User_ID", "dbo.Users");
            DropIndex("dbo.Notifications", new[] { "User_ID" });
            CreateTable(
                "dbo.GameAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AccountIdentifier = c.String(),
                        AccountRegions = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.UserGames", "GameAccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserGames", "GameAccountId", unique: true);
            AddForeignKey("dbo.UserGames", "GameAccountId", "dbo.GameAccounts", "Id", cascadeDelete: true);
            DropColumn("dbo.Notifications", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "User_ID", c => c.Int());
            DropForeignKey("dbo.UserGames", "GameAccountId", "dbo.GameAccounts");
            DropIndex("dbo.UserGames", new[] { "GameAccountId" });
            DropColumn("dbo.UserGames", "GameAccountId");
            DropTable("dbo.GameAccounts");
            CreateIndex("dbo.Notifications", "User_ID");
            AddForeignKey("dbo.Notifications", "User_ID", "dbo.Users", "ID");
        }
    }
}

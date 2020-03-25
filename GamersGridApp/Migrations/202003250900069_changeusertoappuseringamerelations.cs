namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeusertoappuseringamerelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGames", "UserId", "dbo.Users");
            AddColumn("dbo.UserGames", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserGames", "User_Id");
            AddForeignKey("dbo.UserGames", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserGames", new[] { "User_Id" });
            DropColumn("dbo.UserGames", "User_Id");
            AddForeignKey("dbo.UserGames", "UserId", "dbo.Users", "ID", cascadeDelete: true);
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetooldmigrationUsergameUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserGames", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.UserGames", new[] { "GameID", "UserId" });
            DropIndex("dbo.UserGames", new[] { "User_Id" });
            DropColumn("dbo.UserGames", "UserId");
            RenameColumn(table: "dbo.UserGames", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.UserGames", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserGames", new[] { "GameID", "UserId" }, unique: true);
            AddForeignKey("dbo.UserGames", "UserId", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGames", "UserId", "dbo.Users");
            DropIndex("dbo.UserGames", new[] { "GameID", "UserId" });
            AlterColumn("dbo.UserGames", "UserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.UserGames", name: "UserId", newName: "User_Id");
            AddColumn("dbo.UserGames", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserGames", "User_Id");
            CreateIndex("dbo.UserGames", new[] { "GameID", "UserId" }, unique: true);
            AddForeignKey("dbo.UserGames", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

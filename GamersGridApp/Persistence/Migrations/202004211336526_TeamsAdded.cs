namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeamsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        GameID = c.Int(nullable: false),
                        AdminID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.AdminID)
                .ForeignKey("dbo.Games", t => t.GameID)
                .Index(t => t.GameID)
                .Index(t => t.AdminID);
            
            CreateTable(
                "dbo.TeamUsers",
                c => new
                    {
                        TeamID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        Role = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.TeamID, t.UserID })
                .ForeignKey("dbo.Teams", t => t.TeamID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.TeamID)
                .Index(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamUsers", "UserID", "dbo.Users");
            DropForeignKey("dbo.TeamUsers", "TeamID", "dbo.Teams");
            DropForeignKey("dbo.Teams", "GameID", "dbo.Games");
            DropForeignKey("dbo.Teams", "AdminID", "dbo.Users");
            DropIndex("dbo.TeamUsers", new[] { "UserID" });
            DropIndex("dbo.TeamUsers", new[] { "TeamID" });
            DropIndex("dbo.Teams", new[] { "AdminID" });
            DropIndex("dbo.Teams", new[] { "GameID" });
            DropTable("dbo.TeamUsers");
            DropTable("dbo.Teams");
        }
    }
}

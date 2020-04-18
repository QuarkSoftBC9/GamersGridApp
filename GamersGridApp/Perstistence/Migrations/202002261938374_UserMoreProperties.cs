namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserMoreProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfilePhoto", c => c.String(maxLength: 255));
            AddColumn("dbo.Users", "Country", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "City", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Street_Name", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Users", "Street_Number", c => c.Int(nullable: false));
            AddColumn("dbo.Games", "User_ID", c => c.Int());
            CreateIndex("dbo.Games", "User_ID");
            AddForeignKey("dbo.Games", "User_ID", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "User_ID", "dbo.Users");
            DropIndex("dbo.Games", new[] { "User_ID" });
            DropColumn("dbo.Games", "User_ID");
            DropColumn("dbo.Users", "Street_Number");
            DropColumn("dbo.Users", "Street_Name");
            DropColumn("dbo.Users", "City");
            DropColumn("dbo.Users", "Country");
            DropColumn("dbo.Users", "ProfilePhoto");
        }
    }
}

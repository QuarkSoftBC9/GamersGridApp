namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserListCoursesRemmoved : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "User_ID", "dbo.Users");
            DropIndex("dbo.Games", new[] { "User_ID" });
            DropColumn("dbo.Games", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Games", "User_ID", c => c.Int());
            CreateIndex("dbo.Games", "User_ID");
            AddForeignKey("dbo.Games", "User_ID", "dbo.Users", "ID");
        }
    }
}

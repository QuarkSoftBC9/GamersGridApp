namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserIncludeUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "UserAccount_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "UserAccount_Id" });
            AddColumn("dbo.AspNetUsers", "UserAccount_ID", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserAccount_ID");
            AddForeignKey("dbo.AspNetUsers", "UserAccount_ID", "dbo.Users", "ID");
            DropColumn("dbo.Users", "UserAccount_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "UserAccount_Id", c => c.String(nullable: false, maxLength: 128));
            DropForeignKey("dbo.AspNetUsers", "UserAccount_ID", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "UserAccount_ID" });
            DropColumn("dbo.AspNetUsers", "UserAccount_ID");
            CreateIndex("dbo.Users", "UserAccount_Id");
            AddForeignKey("dbo.Users", "UserAccount_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}

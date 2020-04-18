namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAddedIdentityAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserAccount_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Users", "UserAccount_Id");
            AddForeignKey("dbo.Users", "UserAccount_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "UserAccount_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Users", new[] { "UserAccount_Id" });
            DropColumn("dbo.Users", "UserAccount_Id");
        }
    }
}

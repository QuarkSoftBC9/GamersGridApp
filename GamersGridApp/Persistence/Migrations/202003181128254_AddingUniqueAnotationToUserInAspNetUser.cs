namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUniqueAnotationToUserInAspNetUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserAccount_ID", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "UserAccount_ID" });
            RenameColumn(table: "dbo.AspNetUsers", name: "UserAccount_ID", newName: "UserId");
            AlterColumn("dbo.AspNetUsers", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.AspNetUsers", "UserId", unique: true);
            AddForeignKey("dbo.AspNetUsers", "UserId", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserId", "dbo.Users");
            DropIndex("dbo.AspNetUsers", new[] { "UserId" });
            AlterColumn("dbo.AspNetUsers", "UserId", c => c.Int());
            RenameColumn(table: "dbo.AspNetUsers", name: "UserId", newName: "UserAccount_ID");
            CreateIndex("dbo.AspNetUsers", "UserAccount_ID");
            AddForeignKey("dbo.AspNetUsers", "UserAccount_ID", "dbo.Users", "ID");
        }
    }
}

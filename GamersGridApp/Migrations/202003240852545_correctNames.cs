namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctNames : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notifications", "User_ID", "dbo.Users");
            DropIndex("dbo.Notifications", new[] { "User_ID" });
            RenameColumn(table: "dbo.Notifications", name: "User_ID", newName: "UserId");
            AlterColumn("dbo.Notifications", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Notifications", "UserId");
            AddForeignKey("dbo.Notifications", "UserId", "dbo.Users", "ID", cascadeDelete: true);
            DropColumn("dbo.LOLAccounts", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOLAccounts", "MyProperty", c => c.Int(nullable: false));
            DropForeignKey("dbo.Notifications", "UserId", "dbo.Users");
            DropIndex("dbo.Notifications", new[] { "UserId" });
            AlterColumn("dbo.Notifications", "UserId", c => c.Int());
            RenameColumn(table: "dbo.Notifications", name: "UserId", newName: "User_ID");
            CreateIndex("dbo.Notifications", "User_ID");
            AddForeignKey("dbo.Notifications", "User_ID", "dbo.Users", "ID");
        }
    }
}

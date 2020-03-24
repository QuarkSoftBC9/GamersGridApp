namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveUniqueKeyFromFollows : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountLOLs", newName: "LOLAccounts");
            DropIndex("dbo.Follows", new[] { "UserId", "FollowerId" });
            AddColumn("dbo.LOLAccounts", "Region", c => c.Int(nullable: false));
            AddColumn("dbo.LOLAccounts", "MyProperty", c => c.Int(nullable: false));
            CreateIndex("dbo.Follows", "UserId");
            CreateIndex("dbo.Follows", "FollowerId");
            DropColumn("dbo.LOLAccounts", "RevisionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOLAccounts", "RevisionDate", c => c.Long(nullable: false));
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            DropIndex("dbo.Follows", new[] { "UserId" });
            DropColumn("dbo.LOLAccounts", "MyProperty");
            DropColumn("dbo.LOLAccounts", "Region");
            CreateIndex("dbo.Follows", new[] { "UserId", "FollowerId" }, unique: true);
            RenameTable(name: "dbo.LOLAccounts", newName: "AccountLOLs");
        }
    }
}

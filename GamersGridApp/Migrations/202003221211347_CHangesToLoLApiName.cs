namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CHangesToLoLApiName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AccountLOLs", newName: "LOLAccounts");
            AddColumn("dbo.LOLAccounts", "Region", c => c.Int(nullable: false));
            AddColumn("dbo.LOLAccounts", "MyProperty", c => c.Int(nullable: false));
            DropColumn("dbo.LOLAccounts", "RevisionDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOLAccounts", "RevisionDate", c => c.Long(nullable: false));
            DropColumn("dbo.LOLAccounts", "MyProperty");
            DropColumn("dbo.LOLAccounts", "Region");
            RenameTable(name: "dbo.LOLAccounts", newName: "AccountLOLs");
        }
    }
}

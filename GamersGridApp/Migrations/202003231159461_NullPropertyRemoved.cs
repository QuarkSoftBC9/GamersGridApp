namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullPropertyRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.LOLAccounts", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LOLAccounts", "MyProperty", c => c.Int(nullable: false));
        }
    }
}

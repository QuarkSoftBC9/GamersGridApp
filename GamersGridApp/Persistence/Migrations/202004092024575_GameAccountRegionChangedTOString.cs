namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameAccountRegionChangedTOString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.GameAccounts", "AccountRegions", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.GameAccounts", "AccountRegions", c => c.Int(nullable: false));
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeconGaeAccIdentifierAddded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameAccounts", "AccountIdentifier2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameAccounts", "AccountIdentifier2");
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LosesAddedToGameStats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameAccountStats", "Losses", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameAccountStats", "Losses");
        }
    }
}

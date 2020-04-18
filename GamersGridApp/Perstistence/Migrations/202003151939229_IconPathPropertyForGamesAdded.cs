namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IconPathPropertyForGamesAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Games", "SearchIconPath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Games", "SearchIconPath");
        }
    }
}

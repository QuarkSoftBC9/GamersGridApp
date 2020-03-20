namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingProfileProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "ProfilePhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "ProfilePhoto", c => c.String(maxLength: 255));
        }
    }
}

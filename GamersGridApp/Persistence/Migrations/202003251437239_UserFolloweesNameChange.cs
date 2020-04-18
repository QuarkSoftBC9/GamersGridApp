namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFolloweesNameChange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notifications", "Content");
        }
    }
}

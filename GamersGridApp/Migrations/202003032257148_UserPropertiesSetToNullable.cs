namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPropertiesSetToNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "NickName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Country", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "City", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "Country", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "NickName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingStreetAddressAndNumberFromUser : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Street_Name");
            DropColumn("dbo.Users", "Street_Number");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Street_Number", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "Street_Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}

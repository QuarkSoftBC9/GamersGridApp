namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InlcudeAvatarStringPath : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Avatar", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Avatar");
        }
    }
}

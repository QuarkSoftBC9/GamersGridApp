namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNickNamePropToGameAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GameAccounts", "NickName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.GameAccounts", "NickName");
        }
    }
}

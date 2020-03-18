namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserDefaultAvatar : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE [dbo].[Users] SET Avatar = '/Content/Images/UserAvatars/boyAvatar.jpg' WHERE Avatar IS NULL");
            AlterColumn("dbo.Users", "Avatar", c => c.String(nullable: false, defaultValue: "/Content/Images/UserAvatars/boyAvatar.jpg"));
        }
        
        public override void Down()
        {
        }
    }
}

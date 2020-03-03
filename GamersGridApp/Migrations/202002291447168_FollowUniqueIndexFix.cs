namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FollowUniqueIndexFix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Follows", new[] { "UserId" });
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            CreateIndex("dbo.Follows", new[] { "UserId", "FollowerId" }, unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Follows", new[] { "UserId", "FollowerId" });
            CreateIndex("dbo.Follows", "FollowerId", unique: true);
            CreateIndex("dbo.Follows", "UserId", unique: true);
        }
    }
}

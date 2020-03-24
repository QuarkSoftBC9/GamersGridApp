namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingUniqueCombinationOfKeysFollowsTable : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Follows", new[] { "UserId", "FollowerId" });
            CreateIndex("dbo.Follows", "UserId");
            CreateIndex("dbo.Follows", "FollowerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            DropIndex("dbo.Follows", new[] { "UserId" });
            CreateIndex("dbo.Follows", new[] { "UserId", "FollowerId" }, unique: true);
        }
    }
}

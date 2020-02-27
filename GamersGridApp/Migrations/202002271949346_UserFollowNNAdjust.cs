namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFollowNNAdjust : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followers", "UserID", "dbo.Users");
            DropForeignKey("dbo.Followers", "FollowerID", "dbo.Users");
            DropIndex("dbo.Followers", new[] { "UserID" });
            DropIndex("dbo.Followers", new[] { "FollowerID" });
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        FollowerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.FollowerId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId, unique: true)
                .Index(t => t.FollowerId, unique: true);
            
            DropTable("dbo.Followers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        FollowerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.FollowerID });
            
            DropForeignKey("dbo.Follows", "UserId", "dbo.Users");
            DropForeignKey("dbo.Follows", "FollowerId", "dbo.Users");
            DropIndex("dbo.Follows", new[] { "FollowerId" });
            DropIndex("dbo.Follows", new[] { "UserId" });
            DropTable("dbo.Follows");
            CreateIndex("dbo.Followers", "FollowerID");
            CreateIndex("dbo.Followers", "UserID");
            AddForeignKey("dbo.Followers", "FollowerID", "dbo.Users", "ID");
            AddForeignKey("dbo.Followers", "UserID", "dbo.Users", "ID");
        }
    }
}

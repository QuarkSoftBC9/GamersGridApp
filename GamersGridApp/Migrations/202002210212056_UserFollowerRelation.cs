namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFollowerRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        FollowerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.FollowerID })
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Users", t => t.FollowerID)
                .Index(t => t.UserID)
                .Index(t => t.FollowerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followers", "FollowerID", "dbo.Users");
            DropForeignKey("dbo.Followers", "UserID", "dbo.Users");
            DropIndex("dbo.Followers", new[] { "FollowerID" });
            DropIndex("dbo.Followers", new[] { "UserID" });
            DropTable("dbo.Followers");
        }
    }
}

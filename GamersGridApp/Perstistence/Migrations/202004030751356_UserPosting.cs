namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserPosting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPostings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OwnerId = c.Int(nullable: false),
                        PosterId = c.Int(nullable: false),
                        PostingDate = c.DateTime(nullable: false),
                        PostingMessage = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OwnerId)
                .ForeignKey("dbo.Users", t => t.PosterId)
                .Index(t => t.OwnerId)
                .Index(t => t.PosterId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPostings", "PosterId", "dbo.Users");
            DropForeignKey("dbo.UserPostings", "OwnerId", "dbo.Users");
            DropIndex("dbo.UserPostings", new[] { "PosterId" });
            DropIndex("dbo.UserPostings", new[] { "OwnerId" });
            DropTable("dbo.UserPostings");
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VideoAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        GameId = c.Int(),
                        Path = c.String(),
                        DateUploaded = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "UserId", "dbo.Users");
            DropIndex("dbo.Videos", new[] { "UserId" });
            DropTable("dbo.Videos");
        }
    }
}

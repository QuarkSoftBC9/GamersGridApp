namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhotoAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
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
            DropForeignKey("dbo.Photos", "UserId", "dbo.Users");
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropTable("dbo.Photos");
        }
    }
}

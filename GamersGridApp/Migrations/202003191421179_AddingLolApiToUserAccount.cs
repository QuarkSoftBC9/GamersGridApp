namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLolApiToUserAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountLOLs",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        Puuid = c.String(),
                        SummonerLevel = c.Int(nullable: false),
                        AccountId = c.String(),
                        Id = c.String(),
                        RevisionDate = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccountLOLs", "UserId", "dbo.Users");
            DropIndex("dbo.AccountLOLs", new[] { "UserId" });
            DropTable("dbo.AccountLOLs");
        }
    }
}

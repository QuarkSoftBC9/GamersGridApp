namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingLolAccountFromModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccountLOLs", "UserId", "dbo.Users");
            DropIndex("dbo.AccountLOLs", new[] { "UserId" });
            DropTable("dbo.AccountLOLs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AccountLOLs",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        Name = c.String(),
                        Puuid = c.String(),
                        AccountId = c.String(),
                        Id = c.String(),
                        Region = c.Int(nullable: false),
                        SummonerLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateIndex("dbo.AccountLOLs", "UserId");
            AddForeignKey("dbo.AccountLOLs", "UserId", "dbo.Users", "ID");
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingLolAccountFromModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LOLAccounts", "UserId", "dbo.Users");
            DropIndex("dbo.LOLAccounts", new[] { "UserId" });
            DropTable("dbo.LOLAccounts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LOLAccounts",
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
            
            CreateIndex("dbo.LOLAccounts", "UserId");
            AddForeignKey("dbo.LOLAccounts", "UserId", "dbo.Users", "ID");
        }
    }
}

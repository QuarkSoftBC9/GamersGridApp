namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GameAccountsStatsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GameAccountStats",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        KDA = c.String(),
                        Rank = c.String(),
                        Wins = c.Int(nullable: false),
                        HoursPlayed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GameAccounts", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GameAccountStats", "Id", "dbo.GameAccounts");
            DropIndex("dbo.GameAccountStats", new[] { "Id" });
            DropTable("dbo.GameAccountStats");
        }
    }
}

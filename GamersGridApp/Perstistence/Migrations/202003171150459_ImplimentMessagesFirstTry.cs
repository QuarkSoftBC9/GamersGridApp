namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplimentMessagesFirstTry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MessageChats",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MessageString = c.String(),
                        Time = c.DateTime(),
                        User_ID = c.Int(nullable: false),
                        MessageChat_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .ForeignKey("dbo.MessageChats", t => t.MessageChat_ID)
                .Index(t => t.User_ID)
                .Index(t => t.MessageChat_ID);
            
            CreateTable(
                "dbo.MessageChatUsers",
                c => new
                    {
                        MessageChat_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageChat_ID, t.User_ID })
                .ForeignKey("dbo.MessageChats", t => t.MessageChat_ID, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_ID, cascadeDelete: true)
                .Index(t => t.MessageChat_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MessageChatUsers", "User_ID", "dbo.Users");
            DropForeignKey("dbo.MessageChatUsers", "MessageChat_ID", "dbo.MessageChats");
            DropForeignKey("dbo.Messages", "MessageChat_ID", "dbo.MessageChats");
            DropForeignKey("dbo.Messages", "User_ID", "dbo.Users");
            DropIndex("dbo.MessageChatUsers", new[] { "User_ID" });
            DropIndex("dbo.MessageChatUsers", new[] { "MessageChat_ID" });
            DropIndex("dbo.Messages", new[] { "MessageChat_ID" });
            DropIndex("dbo.Messages", new[] { "User_ID" });
            DropTable("dbo.MessageChatUsers");
            DropTable("dbo.Messages");
            DropTable("dbo.MessageChats");
        }
    }
}

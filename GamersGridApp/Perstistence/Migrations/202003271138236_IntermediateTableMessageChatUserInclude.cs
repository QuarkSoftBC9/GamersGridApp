namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntermediateTableMessageChatUserInclude : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.MessageChatUsers", "MessageChat_ID", "dbo.MessageChats");
            //DropForeignKey("dbo.MessageChatUsers", "User_ID", "dbo.Users");
            //DropIndex("dbo.MessageChatUsers", new[] { "MessageChat_ID" });
            //DropIndex("dbo.MessageChatUsers", new[] { "User_ID" });
            DropTable("dbo.MessageChatUsers");
            RenameColumn(table: "dbo.Messages", name: "User_ID", newName: "UserId");
            RenameIndex(table: "dbo.Messages", name: "IX_User_ID", newName: "IX_UserId");
            CreateTable(
                "dbo.MessageChatUsers",
                c => new
                    {
                        MessageChatId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        IsUpToDate = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageChatId, t.UserId })
                .ForeignKey("dbo.MessageChats", t => t.MessageChatId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MessageChatId)
                .Index(t => t.UserId);
            
   
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MessageChatUsers",
                c => new
                    {
                        MessageChat_ID = c.Int(nullable: false),
                        User_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MessageChat_ID, t.User_ID });
            
            DropForeignKey("dbo.MessageChatUsers", "UserId", "dbo.Users");
            DropForeignKey("dbo.MessageChatUsers", "MessageChatId", "dbo.MessageChats");
            DropIndex("dbo.MessageChatUsers", new[] { "UserId" });
            DropIndex("dbo.MessageChatUsers", new[] { "MessageChatId" });
            DropTable("dbo.MessageChatUsers");
            RenameIndex(table: "dbo.Messages", name: "IX_UserId", newName: "IX_User_ID");
            RenameColumn(table: "dbo.Messages", name: "UserId", newName: "User_ID");
            CreateIndex("dbo.MessageChatUsers", "User_ID");
            CreateIndex("dbo.MessageChatUsers", "MessageChat_ID");
            AddForeignKey("dbo.MessageChatUsers", "User_ID", "dbo.Users", "ID", cascadeDelete: true);
            AddForeignKey("dbo.MessageChatUsers", "MessageChat_ID", "dbo.MessageChats", "ID", cascadeDelete: true);
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SearchIconsForGames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE [dbo].[Games] SET SearchIconPath = '/Content/Images/Games/lol.jpg' WHERE ID = 1");
            Sql("UPDATE [dbo].[Games] SET SearchIconPath = '/Content/Images/Games/cs.png' WHERE ID = 6");
            Sql("UPDATE [dbo].[Games] SET SearchIconPath = '/Content/Images/Games/dota2.jpg' WHERE ID = 7");
        }
        
        public override void Down()
        {
        }
    }
}

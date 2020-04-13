namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDotaAndCS : DbMigration
    {
        public override void Up()
        {

            Sql("INSERT INTO Games ( Title, ReleaseDate, Type, Description) VALUES ( 'Dota 2', '2013-07-09 00:00:00.000', 1, 'Dota 2 is a multiplayer online battle arena video game developed and published by Valve. The game is a sequel to Defense of the Ancients, which was a community-created mod for Blizzard Entertainments Warcraft III: Reign of Chaos and its expansion pack, The Frozen Throne.')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Games WHERE Title IN('Dota 2')");
        }
    }
}

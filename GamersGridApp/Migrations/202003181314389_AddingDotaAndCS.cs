namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDotaAndCS : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games ( Title, ReleaseDate, Type, Description) VALUES ( 'Counter-Strike: Global Offensive', '2012-09-21 00:00:00.000', 0," +
                " 'Counter-Strike: Global Offensive is a multiplayer first-person shooter video game developed " +
                "by Valve and Hidden Path Entertainment. It is the fourth game in the Counter-Strike series and was released for Windows, OS X," +
                " Xbox 360, and PlayStation 3 in August 2012, while the Linux version was released in 2014.')");
            Sql("INSERT INTO Games ( Title, ReleaseDate, Type, Description) VALUES ( 'Dota 2', '2013-07-09 00:00:00.000', 1, 'Dota 2 is a multiplayer online battle arena video game developed and published by Valve. The game is a sequel to Defense of the Ancients, which was a community-created mod for Blizzard Entertainments Warcraft III: Reign of Chaos and its expansion pack, The Frozen Throne.')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Games WHERE Title IN('Counter-Strike: Global Offensive','Dota 2')");
        }
    }
}

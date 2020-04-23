namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OvrWatchAdded : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games ( Title, ReleaseDate, Type, Description) VALUES ( 'Overwatch', '2016-05-24 00:00:00.000', 0, 'Overwatch is a team-based multiplayer first-person shooter developed and published by Blizzard Entertainment. Described as a hero shooter, Overwatch assigns players into two teams of six, with each player selecting from a roster of over 30 characters, known as heroes, each with a unique style of play that is divided into three general roles that fit their purpose. Players on a team work together to secure and defend control points on a map or escort a payload across the map in a limited amount of time. Players gain cosmetic rewards that do not affect gameplay, such as character skins and victory poses, as they play the game')");
            Sql("DELETE FROM Games WHERE Title IN('Counter-Strike: Global Offensive')");
        }
        
        public override void Down()
        {
            Sql("INSERT INTO Games ( Title, ReleaseDate, Type, Description) VALUES ( 'Counter-Strike: Global Offensive', '2012-09-21 00:00:00.000', 0," +
                " 'Counter-Strike: Global Offensive is a multiplayer first-person shooter video game developed " +
                "by Valve and Hidden Path Entertainment. It is the fourth game in the Counter-Strike series and was released for Windows, OS X," +
                " Xbox 360, and PlayStation 3 in August 2012, while the Linux version was released in 2014.')");
            Sql("DELETE FROM Games WHERE Title IN('Overwatch')");
        }
    }
}

namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOverwatch : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Games ( Title, ReleaseDate, Type, Description) VALUES ( 'Overwatch', '2016-05-24 00:00:00.000', 0, 'Overwatch is a colorful team-based shooter game starring a diverse cast of powerful heroes. Travel the world, build a team, and contest objectives in exhilarating 6v6 combat..')");

        }

        public override void Down()
        {
            Sql("DELETE FROM GAMES WHERE Title = 'Overwatch')");

        }
    }
}

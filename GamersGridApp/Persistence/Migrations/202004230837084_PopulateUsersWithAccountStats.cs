namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUsersWithAccountStats : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Users ON");

            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (1, N'Orestis', N'Avramidis', N'orestis_A', N'It''s not so important who starts the game but who finishes it.', N'Greece', N'Athens', N'064150c7-67d0-4061-9579-61c4948ed1301.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (2, N'Christina', N'Thanou', N'christina_T', N'If the Earth gets hit by an asteroid, it''s game over. It''s control-alt-delete for civilization.', N'Greece', N'Patra', N'cf05c241-a544-4ff1-8701-ddb5e3903d2a2.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (3, N'Dimitra', N'Mouzaki', N'dimitra_M', N'I don''t like the blame game, though', N'Greece', N'Thessaloniki', N'32bbdafc-a21a-45fd-8312-46af5e3200fb3.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (4, N'Stavros', N'Kalaris', N'stavros_K', N'I look at this game from a different perspective. ', N'Greece', N'Kalamata', N'f6782cc8-565b-402c-9233-69e85cc55fd84.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (5, N'Nikos', N'Liapis', N'nikos_L', N'The fame game''s fun, but it''s not forever.', N'Greece', N'Crete', N'f209a84a-17df-4b9c-82ec-fd10f6e5031f5.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (6, N'George', N'Manolas', N'george_M', N'I mean, I''m on a comic book. I''m in a video game. This is not real life.', N'Greece', N'Astros', N'dec87cc0-e200-43e9-9db2-8e3d543105b96.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (7, N'Victoria', N'Stamou', N'victoria_S', N'When I play, I become entirely absorbed in the game. It may be a form of concentration. ', N'Greece', N'Tinos', N'b31d67c6-a91d-4496-b696-c98f5fb937fe7.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (8, N'Stergios', N'Nikas', N'stergios_N', N'We didn''t lose the game; we just ran out of time.', N'Greece', N'Arta', N'b31b6f8c-00ee-4f3b-9c5d-e25e7414d9178.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (9, N'Foivos', N'Mavridis', N'foivos_M', N'The score never interested me, only the game ', N'Greece', N'Veroia', N'e1016618-cdca-4e6d-a8df-c5eff3d246a99.png')");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, Country, City, Avatar) VALUES (10, N'Kostas', N'Vlastos', N'kostas_V', N'The man who has no problems is out of the game. ', N'Greece', N'Alexandroupoli', N'3973380b-d181-47cf-8a49-0fb461e34fa510.png')");


            Sql("SET IDENTITY_INSERT Users OFF");

            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'01d93e74-9d92-4a02-b522-2651817c544d', N'orestisA@user.com', 0, N'ANJyVLK30SSM+rlj1MxchhPSR+zojwEivTL7qR3lOMBTUMPTdctkX6YZRB+yC8L6mw==', N'98e119c3-3d0b-4e80-b29a-3a88200171ab', NULL, 0, 0, NULL, 1, 0, N'orestisA@user.com', 1)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'1b6189b7-0217-48b6-9d0e-d57210029deb', N'nikosL@user.com', 0, N'AIF/xbUlhVBz5CStW32PLH3DF0kTtAc0JoUtx7N87qy34fTdAwic8lpRjBY2SysKOQ==', N'e9bcf549-53d3-4124-b1ad-eaed29ae61e8', NULL, 0, 0, NULL, 1, 0, N'nikosL@user.com', 5) ");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'2e9ddbc9-1f57-4bd4-bbd9-8a28daef638f', N'dimitraM@user.com', 0, N'ABl/8gMOHUJDQqYDTgo2XYJFWjG+WkctQFLd0gLXtXBtvPt/Fi/oNvqOYr45BarnyA==', N'f04e6364-5697-4717-8351-e18b7cfaafda', NULL, 0, 0, NULL, 1, 0, N'dimitraM@user.com', 3)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'92be8cc5-250a-4792-a785-c32f90d757bb', N'christinaT@user.com', 0, N'AJcapZ9DxytXxTCSzDdyfK6HhO/+sVS2D42mkr3bq7aldlMPR+TJVSvNiUy6Hay1AQ==', N'15783cf4-631b-4937-8c52-9eb83eb5f9db', NULL, 0, 0, NULL, 1, 0, N'christinaT@user.com', 2)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'98b5aee1-1b8a-4f40-bbbc-4737be97a129', N'stergiosN@user.com', 0, N'AOoD98W3JCDKWhLgkqT6RLLo/Tnm1X2t4/Bel841wG//XNaQw+WsNL0tlDK3aboa9g==', N'ba9e25ef-b45e-41fa-9150-32ee267aa34a', NULL, 0, 0, NULL, 1, 0, N'stergiosN@user.com', 8)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'bee81749-25c3-4191-9a82-c5e936554aec', N'victoriaS@user.com', 0, N'AC9bdyHfhOb50ryvn1hG6QVeGCg/vXa9rL+/NhYn/AXKf95F4dMRS29neCKHn/BB0Q==', N'ff36c174-a570-4890-9ca8-c6d39ed8d39c', NULL, 0, 0, NULL, 1, 0, N'victoriaS@user.com', 7)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'c06f9ee8-8ff6-4fc3-8c1f-b33406aa866e', N'stavrosK@user.com', 0, N'ACagfD+9QRkJW7xlaAVdh0GC8GSoDkyApUqmVUXdRiei9wKpMOse+ISk0YEPbM1RAg==', N'7ba1756f-3fb3-4185-8fdd-6de7aed506ac', NULL, 0, 0, NULL, 1, 0, N'stavrosK@user.com', 4)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'd82b5961-aaab-4b3c-92f9-a31b5f749064', N'foivosM@user.com', 0, N'ACbOl9vPluk1u0eWZP3IHk+bR7YoRDsjHiOusQHPuA8YhBWTLsUdwZ0y/S0CEn5wKA==', N'284be574-7a75-4379-8370-fdcdf8b5afa9', NULL, 0, 0, NULL, 1, 0, N'foivosM@user.com', 9)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'ec7eded9-b974-4a25-8a55-ba1093683ea0', N'kostasV@user.com', 0, N'AMGXdCYtJaZiVAahquM3e6FzWDIYdE1bEULA0EOjhmBpDi1mxui1J5uvjkhVFqCinA==', N'2a49bb45-f12d-4305-be79-866af62746c5', NULL, 0, 0, NULL, 1, 0, N'kostasV@user.com', 10)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES (N'f01fbaa2-2e48-4fd5-8976-df34270cee6f', N'georgeM@user.com', 0, N'AISpi1yABhtlHFMH5QesIlmryk/hYESeYpYIq0oviIW/g6Ds7v5awtyDcEUa1h9tiw==', N'4cd4f044-7193-47f8-a758-ab2430d3431a', NULL, 0, 0, NULL, 1, 0, N'georgeM@user.com', 6)");

            Sql("SET IDENTITY_INSERT UserGames ON");

            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 1, 1, 1)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 0, 2, 1)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 0, 3, 1)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 1, 4, 2)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 0, 5, 2)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 1, 6, 3)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 0, 7, 3)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 1, 8, 4)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 0, 9, 4)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 0, 10, 4)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 0, 11, 3)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 0, 12, 2)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 1, 13, 5)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 0, 14, 5)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 0, 15, 5)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 1, 16, 6)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 0, 17, 6)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 0, 18, 6)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 1, 19, 7)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 0, 20, 7)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 0, 21, 7)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 1, 22, 8)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 0, 23, 8)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 0, 24, 8)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 1, 25, 9)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 0, 26, 9)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 0, 27, 9)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (3, 1, 28, 10)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (2, 0, 29, 10)");
            Sql("INSERT INTO UserGames (GameID, IsFavoriteGame, Id, UserId) VALUES (1, 0, 30, 10)");

            Sql("SET IDENTITY_INSERT UserGames OFF");



            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (1, N'ThePrestige~', N'76561198047011640', N'86745912', NULL)");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (2, N'Random#1827', N'Random#1827', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (3, N'Flow Box', N'ryARHVfNGnD0xHZkfYCwmOtk6ABHyoeYBc-7zLkeX2g6cBk', N'PaaZEhytYvRXETXR4LLG7pfDMTOcPQtamrlLwCRiwN_8iA', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (4, N'Aphelios', N'YRu5uV2ZxLwBT7y7AyS8-XK5X65WbwI0unTgYAJDWvy4Fcw', N'wiMDXOALogP0FL3YNB4X2A475O3oNXQt5boY-DcaqcNqygMQNKG4FS1w', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (5, N'New#21352', N'New#21352', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (6, N'PRO#22766', N'PRO#22766', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (7, N'Senna', N'qydzRYSpdoKc0ufJC1qeKsF59jTNSaKDtLDT5z82_p4sd_8', N'FFucFAz3tirBIYLIGTihp6U9WvwKYcw3cMrcaSA6MS4AJ_w', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (8, N'Patr?n', N'76561198030654385', N'70388657', N'UA')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (9, N'Sett', N'pEAxMN8FxeydtCHnjLEPdVugsyNxyxYcIwXgHZypm0kVBCo', N'FgRXI1iAd7CFDEUEQuaSFwKjxFuzl8mcfgZ5Vz47tpkCYr0', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (10, N'Player#164100', N'Player#164100', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (11, N'Mc BOSS', N'105248644', N'76561198065514372', NULL)");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (12, N'binoculars', N'111620041', N'76561198071885769', NULL)");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (13, N'Tokyo Manji', N'K0cLvczI5T96ZhjVg5c5eP9PLJJwXQkBygTVWNeZgrWJOG0', N'5OCkLiISeVUlc07DVzCDFao3A7PWtt3SJQktlDJsEgXfIAI', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (14, N'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', N'40547474', N'76561198000813202', N'CA')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (15, N'gamer#12739', N'gamer#12739', NULL, N'eu')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (16, N'Trueblood#21976', N'Trueblood#21976', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (17, N'Full Confidence', N'19672354', N'76561197979938082', N'DK')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (18, N'Sindo San Senpai', N'vzAuVPkGGZJ-J9s-VxzYAldfzSihGv9EOA8Z-6Z9Q37UU4g', N'4h2-p65hBzvj250-UznQyF8uV6F0VMY-9a21LILzsIr5lk8', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (19, N'Wind boi', N'c7TMTmedkAat1kPwhL0sWYNuDhd_H82dxEw5DLtRYsFZTfU', N'WQaPHqSCRlTummbv9iCCzMqIQAIIyTlAZAhTUj-l4nnhNCY', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (20, N'Puppey', N'87278757', N'76561198047544485', NULL)");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (21, N'ARMY#21395', N'ARMY#21395', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (22, N'??', N'76561197986172872', N'25907144', NULL)");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (23, N'ARMY#21395', N'ARMY#21395', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (24, N'Major Alexander', N'DfhTMR_5cgwUqN7sOXroB-IIbpxRsBjPKCHXVUt3v4_tB_Y', N'7qY4-SeW_LfAXaLwI2Mtgi4oYHlaQ7em7eU043RI1SBFrA', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (25, N'Paresz14', N'v4AVq43rlukw6u9l798ycuLmT3Z8tJOZrn2YrNbiCv4WA8c', N'KKUNOBXVc1QvPuteTX7gMGIej5D1ifYoEApn5H2AoUhcYA', N'EUN1')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (26, N'2pac', N'87177591', N'76561198047443319', NULL)");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (27, N'Crab#11828', N'Crab#11828', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (28, N'Miu#21712', N'Miu#21712', NULL, N'us')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (29, N'w33', N'86700461', N'76561198046966189', N'RO')");
            Sql("INSERT INTO GameAccounts (Id, NickName, AccountIdentifier, AccountIdentifier2, AccountRegions) VALUES (30, N'MomoVeliaDeviluk', N'zYZDfN0ms_pftsAsZCSseQV3WW9PA1N9duNkzCaf9brZ8GU', N'4eFrlqKp7qTPV0gHqbWIjaSG4Tk93mnxg3rpCFhsch8jVA', N'EUN1')");


            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (1, N'4,98', NULL, 1538, 903, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (2, NULL, N'1690', 945, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (3, N'2,53', N'GOLD III', 39, 35, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (4, N'4,64', N'GOLD IV', 13, 3, 0) ");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (5, NULL, N'2406', 564, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (6, N'3,13', N'3393', 277, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (7, N'4,21', N'GOLD II', 219, 214, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (8, N'2,23', NULL, 6054, 5139, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (9, N'1,99', N'SILVER IV', 150, 159, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (10, NULL, N'1818', 999, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (11, NULL, NULL, 2065, 1384, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (12, NULL, N'5631', 4545, 3836, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (13, N'3,39', N'DIAMOND I', 55, 34, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (14, NULL, NULL, 7617, 3310, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (15, NULL, N'0', 55, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (16, N'1,76', N'1596', 1847, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (17, NULL, NULL, 1255, 761, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (18, N'2,51', N'DIAMOND IV', 174, 156, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (19, N'0,00', N'PLATINUM I', 41, 39, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (20, NULL, NULL, 1678, 809, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (21, NULL, N'2281', 1373, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (22, N'4,07', N'4904', 7330, 6159, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (23, NULL, N'2281', 1373, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (24, N'6,82', N'DIAMOND IV', 11, 3, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (25, N'4,46', N'PLATINUM I', 22, 3, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (26, NULL, NULL, 5602, 4194, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (27, NULL, N'2625', 146, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (28, N'2,14', N'1351', 249, 0, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (29, NULL, NULL, 5177, 4141, 0)");
            Sql("INSERT INTO GameAccountStats (Id, KDA, Rank, Wins, Losses, HoursPlayed) VALUES (30, N'1,64', N'CHALLENGER I', 82, 38, 0)");


        }

        public override void Down()
        {
        }
    }
}

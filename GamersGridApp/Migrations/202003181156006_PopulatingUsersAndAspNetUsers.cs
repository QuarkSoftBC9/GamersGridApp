namespace GamersGridApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulatingUsersAndAspNetUsers : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Users ON");

            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, ProfilePhoto, Country, City, Avatar) VALUES (6, NULL, NULL, 'user1', NULL, NULL, 'Greece', 'Athens', NULL)");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, ProfilePhoto, Country, City, Avatar) VALUES (7, NULL, NULL, 'user2', NULL, NULL, 'Chile', 'San Paolo', NULL)");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, ProfilePhoto, Country, City, Avatar) VALUES (8, NULL, NULL, 'user3', NULL, NULL, 'Germany', 'Berlin', NULL)");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, ProfilePhoto, Country, City, Avatar) VALUES (9, NULL, NULL, 'user4', NULL, NULL, 'Japan', 'Tokyo', NULL)");
            Sql("INSERT INTO Users (ID, FirstName, LastName, NickName, Description, ProfilePhoto, Country, City, Avatar) VALUES (10, NULL, NULL, 'user5', NULL, NULL, 'India', 'Mumbai', NULL)");

            Sql("SET IDENTITY_INSERT Users OFF");

            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES ('285fc449-d845-462a-9ccd-ff8fec8866c2', 'user1@user.com', 0, 'ADWd76aVBBlYf73Lcg7J4H5VcdOl0YLdkpGR7gOBFkOtIVvwcUywAIWZA0F1tDiezg==', '19183237-6f7d-4495-8c82-ad586a13534b', NULL, 0, 0, NULL, 1, 0, 'user1@user.com', 6)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES ('37c05d3e-6e6b-4e29-911e-9613c8a5f972', 'user3@user.com', 0, 'AC8oROsWHRi4AH7WCk3L8cjr2n1jzIfX819s/0dIGMgtWIxhj4X1vEv8MLsU7+x+/w==', 'a33c819c-5df3-482e-8878-e4701ce8fb10', NULL, 0, 0, NULL, 1, 0, 'user3@user.com', 8)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES ('7d277920-0b1e-4815-a9bf-895b41f9f08f', 'user4@user.com', 0, 'ADD3NTWJmCq1ryZkjziAQ28F1G6AfEivXIfyJ8PdRqvtGSuueAami3r2vIySinRvuw==', 'fedad4e8-7d85-4cbd-ba9b-8de4f5fd391d', NULL, 0, 0, NULL, 1, 0, 'user4@user.com', 9)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES ('7f4c7b1c-0676-4212-8eb8-a3f4513940e0', 'user5@user.com', 0, 'AMTvFAl0QtbGuR9GuLZcZBF9kfcNlNqerM4Dk88TTHyJcHcLVUneR4xAPF0ea2AsWQ==', '9fa402af-f5b2-4a3d-9ff6-7d42bf0172c1', NULL, 0, 0, NULL, 1, 0, 'user5@user.com', 10)");
            Sql("INSERT INTO AspNetUsers (Id, Email, EmailConfirmed, PasswordHash, SecurityStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEndDateUtc, LockoutEnabled, AccessFailedCount, UserName, UserId) VALUES ('b59b6bac-2f2e-42bb-8891-7e502fbf456d', 'user2@user.com', 0, 'AJ8QSSVGDYTS0Lt3bqHEt6TE9yzgJkbql6RlRjpQ9VhL72VdC7kXW8/V1PUC05Xq3g==', '06be1722-7d57-442e-b015-bbbdf1bbfc29', NULL, 0, 0, NULL, 1, 0, 'user2@user.com', 7)");

        }
        public override void Down()
        {
            Sql("DELETE FROM AspNetUsers WHERE ID IN( '285fc449-d845-462a-9ccd-ff8fec8866c2', '37c05d3e-6e6b-4e29-911e-9613c8a5f972' , '7d277920-0b1e-4815-a9bf-895b41f9f08f', '7f4c7b1c-0676-4212-8eb8-a3f4513940e0', 'b59b6bac-2f2e-42bb-8891-7e502fbf456d')");
            Sql("DELETE FROM Users WHERE ID IN(6,7,8,9, 19)");
        }
    }
}

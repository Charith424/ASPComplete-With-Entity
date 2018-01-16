namespace ASPComplete.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'267df5c0-b308-4703-81b3-7ecbf4d3c317', N'Admin@Test.com', 0, N'AGb70hesInKEaOUIvuPEm2MmaHRXldHaNCfHwYTpH3jD3Jj584Ye+2NifWPLUUUi/A==', N'f111a6e2-ffb6-4511-a11e-b10034960088', NULL, 0, 0, NULL, 1, 0, N'Admin@Test.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2e6acafc-4417-4ff2-b0a0-ed692582e7f9', N'guest@gmail.com', 0, N'AN5vB/l7c7xda3DoqyVvwhgolawpzvPVV+pbzg0WLFy05DUrFej4UMACiomQfWL+GA==', N'fea085cf-7a85-44da-ad15-05628874085b', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8cca111a-c86a-4c38-b0ef-29ebc57048fd', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'267df5c0-b308-4703-81b3-7ecbf4d3c317', N'8cca111a-c86a-4c38-b0ef-29ebc57048fd')

"

                );
        }
        
        public override void Down()
        {
        }
    }
}

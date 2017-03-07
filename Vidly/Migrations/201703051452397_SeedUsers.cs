using System.Data.SqlClient;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2e64fddd-c060-4e1f-9885-d171d1d4468c', N'admin@vidly.com', 0, N'ANVG1Lol74JKrH2l5wQCPU7hJVPD77+SQv/LJgsEjAZ4PGaNI2IryM2KeVV5ibPeVA==', N'08616008-68c7-4b1c-94da-aa4717f126f8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9026d5d3-8f9f-430f-a09c-17a271a73d1c', N'guest@vidly.com', 0, N'AIKkphlaKoFC2SgZWZMdd5hei8Mn9CGXYTQf0wtAQ1bp0imuaFmvuMThyZXPetEkiw==', N'45e6cf42-d8ed-4da7-93c5-cea057607581', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'af2e0087-cf9f-4daa-9eb0-8d176e73814b', N'pavoleg2009@gmail.com', 0, N'AJ9E1MoLqqgI6zTHwM/L26xE26LQucnWPCkqH5/smQqgmP+OJQKfV5K9hnr1fb1hvA==', N'92c4c79f-8bf5-4cc1-b199-1894fc9e1e02', NULL, 0, 0, NULL, 1, 0, N'pavoleg2009@gmail.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4ab23914-91b6-40e6-82a3-12c9efcaefd0', N'CanManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2e64fddd-c060-4e1f-9885-d171d1d4468c', N'4ab23914-91b6-40e6-82a3-12c9efcaefd0')
            ");




        }

        
        public override void Down()
        {
        }
    }
}

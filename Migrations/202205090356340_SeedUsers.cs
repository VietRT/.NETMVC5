namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e9e9a5cb-a664-465c-97e2-abf5e92584a4', N'admin@vidly.com', 0, N'AMrb67iaQzNqVzl0Vrt1W9nqyKyCqYU/K035b9M8nXMQPXRF4IzQirARn5yZeTZraw==', N'2f225b47-7edb-4106-80f8-b0982e1ec7c4', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ea251571-4adc-4bff-b169-1a063ffbe3be', N'guest@vidley.com', 0, N'AEdEBFzhUOFsIKVYw6cfU7WpO+/x/9XQo6sjj5hAT2XqRBHlcUKCq8/tp08fP5uHbg==', N'1185cf20-78f3-4540-a9c4-91503cb16aec', NULL, 0, 0, NULL, 1, 0, N'guest@vidley.com')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'41b9e35b-efc5-4f4e-a9db-78f7771e55ae', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e9e9a5cb-a664-465c-97e2-abf5e92584a4', N'41b9e35b-efc5-4f4e-a9db-78f7771e55ae')

                ");
        }
        
        public override void Down()
        {
        }
    }
}

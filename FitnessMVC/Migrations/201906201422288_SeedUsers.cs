namespace FitnessMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'584d8724-a908-44bc-8943-d893da7f1e08', N'admin@gmail.com', 0, N'AKCGwh+nkXD/rC8KP4g/3+Nf/oupg8P2M1shCRVEgEtkwBOU4bVxK74aJjy6eowrIQ==', N'ba6de2f4-7c13-4240-9b76-a7792421a58d', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'838f667b-7f8a-4b59-870d-49705a2df681', N'manager@gmail.com', 0, N'AKQVQOV1gV9kWr+wqXd3Wpw2v3a9mbJNqpUBNe4/U66szSq7OTTVaR8cP8L9FgSjPA==', N'e28ff492-6074-44fe-af1c-deb6305a06e4', NULL, 0, 0, NULL, 1, 0, N'manager@gmail.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'fa23190d-1878-40cc-8b52-09674944b4ff', N'Admin')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'4066b8f8-f940-4586-826d-728d41da81d8', N'CanManagePrograms')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'838f667b-7f8a-4b59-870d-49705a2df681', N'4066b8f8-f940-4586-826d-728d41da81d8')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'584d8724-a908-44bc-8943-d893da7f1e08', N'fa23190d-1878-40cc-8b52-09674944b4ff')

            ");
        }
        
        public override void Down()
        {
        }
    }
}

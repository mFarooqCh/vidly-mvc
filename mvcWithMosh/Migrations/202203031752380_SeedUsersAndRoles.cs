namespace mvcWithMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsersAndRoles : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'58fa2286-c60d-4118-a3c9-123e3d880ac7', N'customersManager@mvcwithmosh.com', 0, N'AIR/B8fnb0RSJ1OKJrTN4Hq29ZV4wYETVaLUY/Sg8kKFsSCI3Uy3Ecd3dFw3odDk0g==', N'b9fa291f-a4a5-4073-82a0-6dff60e210e9', NULL, 0, 0, NULL, 1, 0, N'customersManager@mvcwithmosh.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9632b0dc-1386-4acd-aae4-7d00813d29d1', N'moviesManager@mvcwithmosh.com', 0, N'AK95pmnmHqEd5yx54QntmdX6OYOoZnqJEbzCEtAhxgul3u5b88mnNhF+WLoGswQFEQ==', N'84d77763-e22d-4f81-9e78-aa958554660a', NULL, 0, 0, NULL, 1, 0, N'moviesManager@mvcwithmosh.com')
                
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'31463cec-699c-4140-bddd-6ef2e0c8b746', N'ManageCustomers')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9af18d2c-2f63-4c63-a9e2-94d8a804873f', N'ManageMovies')
                
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'58fa2286-c60d-4118-a3c9-123e3d880ac7', N'31463cec-699c-4140-bddd-6ef2e0c8b746')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9632b0dc-1386-4acd-aae4-7d00813d29d1', N'9af18d2c-2f63-4c63-a9e2-94d8a804873f')
            ");

             //moviesManager @mvcwithmosh.com
             //MoviesManager@1234
             //customersManager @mvcwithmosh.com
             //CustomersManager@1234
        }

        public override void Down()
        {
        }
    }
}

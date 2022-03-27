namespace mvcWithMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAppDbContext : DbMigration
    {
        public override void Up()
        {

        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DateOfBirth");
            DropTable("dbo.Movies");
        }
    }
}

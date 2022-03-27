namespace mvcWithMosh.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsSubscriber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubscriber", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscriber");
        }
    }
}

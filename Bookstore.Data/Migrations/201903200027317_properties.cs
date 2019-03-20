namespace Bookstore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class properties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Inventory", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "Description", c => c.String(nullable: false));
            DropColumn("dbo.Books", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Description");
            DropColumn("dbo.Books", "Inventory");
        }
    }
}

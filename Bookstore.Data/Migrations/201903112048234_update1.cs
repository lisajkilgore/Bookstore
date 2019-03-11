namespace Bookstore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "ItemTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Carts", "ItemCost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "ItemCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Carts", "ItemTotal");
        }
    }
}

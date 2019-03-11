namespace Bookstore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class itemcost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "ItemCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "ItemCost");
        }
    }
}

namespace Bookstore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Carts", "CartTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "CartTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Carts", "Title");
        }
    }
}

namespace Bookstore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Carts", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Carts", "Title", c => c.String(nullable: false));
        }
    }
}

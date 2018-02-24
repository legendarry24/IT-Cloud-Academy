namespace ElectronicShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MagrateDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchases", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchases", "Date");
        }
    }
}

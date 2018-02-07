namespace Entity_Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Phones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manufacturer = c.String(),
                        Model = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Laptops",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Manufacturer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Phones", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Phones", new[] { "DepartmentId" });
            DropTable("dbo.Laptops");
            DropTable("dbo.Phones");
            DropTable("dbo.Departments");
        }
    }
}

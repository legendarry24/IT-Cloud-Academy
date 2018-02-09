namespace Entity_Framework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Afewentitieswereadded : DbMigration
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
                "dbo.PhoneConfigs",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Resolution = c.String(),
                        Proccess = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Phones", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LaptopPersons",
                c => new
                    {
                        Laptop_Id = c.Guid(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Laptop_Id, t.Person_Id })
                .ForeignKey("dbo.Laptops", t => t.Laptop_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Laptop_Id)
                .Index(t => t.Person_Id);
            
            AddColumn("dbo.Phones", "DepartmentId", c => c.Int());
            CreateIndex("dbo.Phones", "DepartmentId");
            AddForeignKey("dbo.Phones", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LaptopPersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.LaptopPersons", "Laptop_Id", "dbo.Laptops");
            DropForeignKey("dbo.Phones", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.PhoneConfigs", "Id", "dbo.Phones");
            DropIndex("dbo.LaptopPersons", new[] { "Person_Id" });
            DropIndex("dbo.LaptopPersons", new[] { "Laptop_Id" });
            DropIndex("dbo.PhoneConfigs", new[] { "Id" });
            DropIndex("dbo.Phones", new[] { "DepartmentId" });
            DropColumn("dbo.Phones", "DepartmentId");
            DropTable("dbo.LaptopPersons");
            DropTable("dbo.People");
            DropTable("dbo.PhoneConfigs");
            DropTable("dbo.Departments");
        }
    }
}

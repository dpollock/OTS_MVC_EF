namespace OTS_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmployeeSales : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Salesperson_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Salesperson_Id)
                .Index(t => t.Salesperson_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sales", "Salesperson_Id", "dbo.Employees");
            DropIndex("dbo.Sales", new[] { "Salesperson_Id" });
            DropTable("dbo.Sales");
        }
    }
}

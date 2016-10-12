namespace OTS_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SalaryToEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Employees", "Name", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "Salary");
        }
    }
}

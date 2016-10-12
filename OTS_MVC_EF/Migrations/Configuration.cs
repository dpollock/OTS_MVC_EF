using OTS_MVC_EF.Models;

namespace OTS_MVC_EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OTS_MVC_EF.Models.SalesDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OTS_MVC_EF.Models.SalesDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var prasad = new Employee() {Name = "Prasad", Position = "Developer", Salary = 5};
            prasad.SalesIMade.Add(new Sale() {Amount = 10000, Description = "Widgets"});

            context.Employees.AddOrUpdate(
                e=>e.Name,
                prasad,
                new Employee() {  Name = "Daniel", Position = "Developer", Salary = 1},
                new Employee() {  Name = "Dhanya", Position = "PM", Salary = 5,  }
                );

            context.SaveChanges();
        }
    }
}

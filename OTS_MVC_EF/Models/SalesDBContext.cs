using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OTS_MVC_EF.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SalesDBContext : DbContext
    {
        // Your context has been configured to use a 'SalesDBContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'OTS_MVC_EF.Models.SalesDBContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SalesDBContext' 
        // connection string in the application configuration file.
        public SalesDBContext()
            : base("name=SalesDBContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }
        public string Position { get; set; }
        
        [Required]
        public decimal Salary { get; set; }

        public  virtual ICollection<Sale> SalesIMade { get; set; } = new List<Sale>();
    }

    public class Sale
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public Employee Salesperson { get; set; }
    }
}
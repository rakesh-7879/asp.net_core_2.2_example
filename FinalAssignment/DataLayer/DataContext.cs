using FinalAssignment.DataLayer.Config;
using FinalAssignment.DataLayer.Entiry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Department> Users { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Appraisal> Appraisals { get; set; }
        public DbSet<Test1> Test1s { get; set; }
        public DbSet<Test2> Test2s { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new DepartmentConfig());
            builder.ApplyConfiguration(new StateConfig());
            builder.ApplyConfiguration(new CityConfig());
            builder.ApplyConfiguration(new EmployeeConfig());
            builder.ApplyConfiguration(new AppraisalConfig());
            builder.ApplyConfiguration(new Test1Config());
            builder.ApplyConfiguration(new Test2Config());
        }
    }
}

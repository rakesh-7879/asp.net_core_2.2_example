using FinalAssignment.DataLayer.Entiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Config
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasKey(x => x.EmployeeId);
            builder.Property(x => x.EmployeeName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DateOfBirth).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(256);
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.CityId).IsRequired();
            builder.Property(x => x.Zip).IsRequired().HasMaxLength(6);
            builder.Property(x => x.JoiningDate).IsRequired();
            builder.Property(x => x.LeavingDate);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.LastModificationDate).IsRequired();

        }
    }
}

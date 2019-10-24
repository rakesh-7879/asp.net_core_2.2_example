using FinalAssignment.DataLayer.Entiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Config
{
    public class Test1Config : IEntityTypeConfiguration<Test1>
    {
        public void Configure(EntityTypeBuilder<Test1> builder)
        {
            builder.ToTable("Test1");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name);

            builder.HasMany(x => x.Test2s).WithOne().HasForeignKey(x => x.TestId);
        }
    }
}

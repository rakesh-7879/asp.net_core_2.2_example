using FinalAssignment.DataLayer.Entiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Config
{
    public class Test2Config : IEntityTypeConfiguration<Test2>
    {
        public void Configure(EntityTypeBuilder<Test2> builder)
        {
            builder.ToTable("Test2");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TestId);
            builder.Property(x => x.Name);
        }
    }
}

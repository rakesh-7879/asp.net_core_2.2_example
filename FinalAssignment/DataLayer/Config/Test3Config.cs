using FinalAssignment.DataLayer.Entiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Config
{
    public class Test3Config : IEntityTypeConfiguration<Test3>
    {
        public void Configure(EntityTypeBuilder<Test3> builder)
        {
            builder.ToTable("Test3");
            builder.HasKey(x => x.Id);
        }
    }
}

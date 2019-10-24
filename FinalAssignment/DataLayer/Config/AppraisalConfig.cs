using FinalAssignment.DataLayer.Entiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalAssignment.DataLayer.Config
{
    public class AppraisalConfig : IEntityTypeConfiguration<Appraisal>
    {
        public void Configure(EntityTypeBuilder<Appraisal> builder)
        {
            builder.ToTable("Appraisals");
            builder.HasKey(x => x.AppraisalId);
            builder.Property(x => x.CurrentAppraisal).IsRequired();
            builder.Property(x => x.Remark).HasMaxLength(250);
        }
    }
}

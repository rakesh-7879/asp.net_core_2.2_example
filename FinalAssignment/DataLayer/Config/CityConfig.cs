using FinalAssignment.DataLayer.Entiry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalAssignment.DataLayer.Config
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("Citys");
            builder.HasKey(x => x.CityId);
            builder.Property(x => x.CityName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.StateId).IsRequired();
        }
    }
}

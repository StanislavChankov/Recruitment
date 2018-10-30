using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Data.Common.Configurations
{
    [ExcludeFromCodeCoverage]
    public sealed class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("City");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);

            builder
                .HasOne(c => c.Country)
                .WithMany(c => c.Cities)
                .HasForeignKey(c => c.CountryId);

            builder
                .HasMany(c => c.CandidateInfos)
                .WithOne(ci => ci.City)
                .HasForeignKey(ci => ci.CityId);
        }
    }
}

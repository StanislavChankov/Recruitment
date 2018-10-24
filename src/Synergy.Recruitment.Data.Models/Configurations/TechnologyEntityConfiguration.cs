using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Technology"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Technology}" />
    public sealed class TechnologyEntityConfiguration : IEntityTypeConfiguration<Technology>
    {
        public void Configure(EntityTypeBuilder<Technology> builder)
        {
            builder.ToTable("Technology");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name).IsRequired().HasMaxLength(60);
        }
    }
}

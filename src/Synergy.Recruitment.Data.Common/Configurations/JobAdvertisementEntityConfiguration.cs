using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Data.Common.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="JobAdvertisement"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{JobAdvertisement}" />
    [ExcludeFromCodeCoverage]
    public sealed class JobAdvertisementEntityConfiguration : IEntityTypeConfiguration<JobAdvertisement>
    {
        /// <summary>
        /// Configures the entity of type <see cref="JobAdvertisement"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<JobAdvertisement> builder)
        {
            builder.ToTable("JobAdvertisement");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(200);

            builder
                .HasOne(ja => ja.Position)
                .WithMany(p => p.JobAdvertisments)
                .HasForeignKey(ja => ja.PositionId);

            // Optional
            builder
                .HasMany(ja => ja.CandidateJobAdvertisments)
                .WithOne(cja => cja.JobAdvertisment)
                .HasForeignKey(cja => cja.JobAdvertismentId);
        }
    }
}

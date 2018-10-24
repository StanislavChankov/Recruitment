using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="CandidateInfo"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{CandidateInfo}" />
    public sealed class CandidateInfoEntityConfiguration : IEntityTypeConfiguration<CandidateInfo>
    {
        /// <summary>
        /// Configures the entity of type <see cref="CandidateInfo"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<CandidateInfo> builder)
        {
            builder.ToTable("CandidateInfo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(60);
            builder.Property(x => x.EmailAddress).IsRequired().HasMaxLength(60);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(60);

            builder
                .HasOne(ci => ci.City)
                .WithMany(c => c.CandidateInfos)
                .HasForeignKey(ci => ci.CityId);

            // Optional
            builder
                .HasMany(ci => ci.Candidates)
                .WithOne(c => c.CandidateInfo)
                .HasForeignKey(c => c.CandidateInfoId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Candidate"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Candidate}" />
    public sealed class CandidateEntityConfiguration : IEntityTypeConfiguration<Candidate>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Candidate"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidate");

            builder.HasKey(x => x.Id);


            builder
                .HasOne(c => c.CandidateInfo)
                .WithMany(ci => ci.Candidates)
                .HasForeignKey(c => c.CandidateInfoId);

            // Optional
            builder
                .HasMany(c => c.Interviews)
                .WithOne(i => i.Candidate)
                .HasForeignKey(c => c.CandidateId);

            builder
                .HasMany(c => c.CandidateCompanies)
                .WithOne(i => i.Candidate)
                .HasForeignKey(c => c.CandidateId);

            builder
                .HasMany(c => c.CandidateJobAdvertisments)
                .WithOne(i => i.Candidate)
                .HasForeignKey(c => c.CandidateId);
        }
    }
}

using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Data.Common.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Interview"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Interview}" />
    [ExcludeFromCodeCoverage]
    public sealed class InterviewEntityConfiguration : IEntityTypeConfiguration<Interview>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Interview"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.ToTable("Interview");

            builder.HasKey(x => x.Id);

            builder
                .HasOne(i => i.InterviewType)
                .WithMany(it => it.Interviews)
                .HasForeignKey(i => i.InterviewTypeId);

            builder
                .HasOne(i => i.Candidate)
                .WithMany(c => c.Interviews)
                .HasForeignKey(i => i.CandidateId);
        }
    }
}

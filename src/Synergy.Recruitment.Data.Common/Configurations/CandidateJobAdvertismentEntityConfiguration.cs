using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Data.Common.Configurations
{
    [ExcludeFromCodeCoverage]
    public sealed class CandidateJobAdvertismentEntityConfiguration : IEntityTypeConfiguration<CandidateJobAdvertisment>
    {
        public void Configure(EntityTypeBuilder<CandidateJobAdvertisment> builder)
        {
            builder.ToTable("CandidateJobAdvertisment");

            builder.HasKey(x => x.Id);
            
            builder
                .HasOne(cja => cja.Candidate)
                .WithMany(c => c.CandidateJobAdvertisments)
                .HasForeignKey(cja => cja.CandidateId);

            builder
                .HasOne(cja => cja.JobAdvertisment)
                .WithMany(ja => ja.CandidateJobAdvertisments)
                .HasForeignKey(cja => cja.JobAdvertismentId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    public sealed class CandidateCompanyEntityConfiguration : IEntityTypeConfiguration<CandidateCompany>
    {
        public void Configure(EntityTypeBuilder<CandidateCompany> builder)
        {
            builder.ToTable("CandidateCompany");

            builder.HasKey(x => x.Id);
            
            builder
                .HasOne(cc => cc.Candidate)
                .WithMany(c => c.CandidateCompanies)
                .HasForeignKey(cc => cc.CandidateId);

            builder
               .HasOne(cc => cc.Company)
               .WithMany(c => c.CandidateCompanies)
               .HasForeignKey(c => c.CompanyId);
        }
    }
}

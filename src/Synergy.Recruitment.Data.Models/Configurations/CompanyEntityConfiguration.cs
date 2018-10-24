using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    public sealed class CompanyEntityConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Company");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(30);

            builder
                .HasMany(c => c.CandidateCompanies)
                .WithOne(cc => cc.Company)
                .HasForeignKey(cc => cc.CompanyId);
        }
    }
}

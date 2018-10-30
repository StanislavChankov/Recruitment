using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Data.Common.Configurations
{
    [ExcludeFromCodeCoverage]
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

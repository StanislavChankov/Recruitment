using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Organization"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Organization}" />
    public sealed class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization");

            builder.HasKey(o => o.Id);

            // Optional
            builder
                .HasMany(o => o.RoleActionOrganizations)
                .WithOne(o => o.Organization)
                .HasForeignKey(o => o.OrganizationId);
        }
    }
}

using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Common.Configurations.Identity
{
    /// <summary>
    /// Configurational class for <see cref="Organization"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Organization}" />
    [ExcludeFromCodeCoverage]
    public sealed class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization", Constants.IDENTITY_SCHEMA);

            builder.HasKey(o => o.Id);

            builder.HasIndex(o => o.Name).IsUnique();

            // Optional
            builder
                .HasMany(o => o.RoleActionOrganizations)
                .WithOne(o => o.Organization)
                .HasForeignKey(o => o.OrganizationId);

            builder
                .HasMany(o => o.SystemUsers)
                .WithOne(o => o.Organization)
                .HasForeignKey(o => o.OrganizationId);
        }
    }
}

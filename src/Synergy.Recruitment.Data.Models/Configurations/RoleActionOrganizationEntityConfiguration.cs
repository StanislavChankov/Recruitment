using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Models.Configurations
{    /// <summary>
     /// Configurational class for <see cref="RoleActionOrganization"/> entity.
     /// </summary>
     /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RoleActionOrganization}" />
    public sealed class RoleActionOrganizationEntityConfiguration : IEntityTypeConfiguration<RoleActionOrganization>
    {
        public void Configure(EntityTypeBuilder<RoleActionOrganization> builder)
        {
            builder.ToTable("RoleActionOrganization", Constants.IDENTITY_SCHEMA);

            builder.HasKey(rao => rao.Id);

            builder
                .HasOne(rao => rao.Role)
                .WithMany(rao => rao.RoleActionOrganizations)
                .HasForeignKey(rao => rao.RoleId);

            builder
                .HasOne(rao => rao.Action)
                .WithMany(rao => rao.RoleActionOrganizations)
                .HasForeignKey(rao => rao.ActionId);

            builder
                .HasOne(rao => rao.Organization)
                .WithMany(rao => rao.RoleActionOrganizations)
                .HasForeignKey(rao => rao.OrganizationId);

            // Optional
            builder
                .HasMany(rao => rao.RoleActionUsers)
                .WithOne(rao => rao.RoleActionOrganization)
                .HasForeignKey(rao => rao.RoleActionOrganizationId);
        }
    }
}

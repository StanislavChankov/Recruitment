using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Common.Configurations.Identity
{
    /// <summary>
    /// Configurational class for <see cref="DefaultRoleAction"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{DefaultRoleAction}" />
    [ExcludeFromCodeCoverage]
    public class DefaultRoleActionConfiguration : IEntityTypeConfiguration<DefaultRoleAction>
    {
        public void Configure(EntityTypeBuilder<DefaultRoleAction> builder)
        {
            builder.ToTable("DefaultRoleAction", Constants.IDENTITY_SCHEMA);

            builder.HasKey(dro => dro.Id);

            builder
                .HasOne(dro => dro.Role)
                .WithMany(r => r.DefaultRoleActions)
                .HasForeignKey(rao => rao.RoleId);

            builder
                .HasOne(rao => rao.Action)
                .WithMany(a => a.DefaultRoleActions)
                .HasForeignKey(rao => rao.ActionId);
        }
    }
}

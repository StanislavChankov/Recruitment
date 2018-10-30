using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Common.Configurations.Identity
{
    /// <summary>
    /// Configurational class for <see cref="Action"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Action}" />
    [ExcludeFromCodeCoverage]
    public sealed class ActionEntityConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.ToTable("Action", Constants.IDENTITY_SCHEMA);

            builder.HasKey(a => a.Id);

            // Optional
            builder
                .HasMany(a => a.RoleActionOrganizations)
                .WithOne(a => a.Action)
                .HasForeignKey(a => a.ActionId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Action"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Action}" />
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

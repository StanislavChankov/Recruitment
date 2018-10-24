using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="RoleActionUser"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{RoleActionUser}" />
    public sealed class RoleActionUserEntityConfiguration : IEntityTypeConfiguration<RoleActionUser>
    {
        public void Configure(EntityTypeBuilder<RoleActionUser> builder)
        {
            builder.ToTable("RoleActionUser");

            builder.HasKey(rau => rau.Id);

            builder
                .HasOne(rau => rau.SystemUser)
                .WithMany(rau => rau.RoleActionUsers)
                .HasForeignKey(rau => rau.SystemUserId);

            builder
                .HasOne(rau => rau.RoleActionOrganization)
                .WithMany(rau => rau.RoleActionUsers)
                .HasForeignKey(rau => rau.RoleActionOrganizationId);
        }
    }
}

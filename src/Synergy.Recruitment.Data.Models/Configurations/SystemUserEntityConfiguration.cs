using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="SystemUser"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SystemUser}" />
    public sealed class SystemUserEntityConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable("SystemUser");

            builder.HasKey(su => su.Id);

            builder
                .HasOne(su => su.Person)
                .WithMany(su => su.SystemUsers)
                .HasForeignKey(su => su.PersonId);

            // Optional
            builder
                .HasMany(su => su.SystemUserPasswords)
                .WithOne(su => su.SystemUser)
                .HasForeignKey(su => su.SystemUserId);

            builder
                .HasMany(su => su.RoleActionUsers)
                .WithOne(su => su.SystemUser)
                .HasForeignKey(su => su.SystemUserId);
        }
    }
}

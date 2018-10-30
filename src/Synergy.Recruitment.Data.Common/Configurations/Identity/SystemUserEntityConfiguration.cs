using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Common.Configurations.Identity
{
    /// <summary>
    /// Configurational class for <see cref="SystemUser"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SystemUser}" />
    [ExcludeFromCodeCoverage]
    public sealed class SystemUserEntityConfiguration : IEntityTypeConfiguration<SystemUser>
    {
        public void Configure(EntityTypeBuilder<SystemUser> builder)
        {
            builder.ToTable("SystemUser", Constants.IDENTITY_SCHEMA);

            builder.HasKey(su => su.Id);

            builder
                .HasOne(su => su.Organization)
                .WithMany(su => su.SystemUsers)
                .HasForeignKey(su => su.OrganizationId)
                .OnDelete(DeleteBehavior.Restrict);

            // 1:1 relation SystemUsePassword - SystemUser
            builder
                .HasOne(su => su.SystemUserPassword)
                .WithOne(p => p.SystemUser)
                .HasForeignKey<SystemUser>(su => su.SystemUserPasswordId);

            // 1:1 relation SystemUser - Person
            builder
                .HasOne(su => su.Person)
                .WithOne(p => p.SystemUser)
                .HasForeignKey<SystemUser>(su => su.PersonId);

            builder
                .HasMany(su => su.RoleActionUsers)
                .WithOne(su => su.SystemUser)
                .HasForeignKey(su => su.SystemUserId);
        }
    }
}

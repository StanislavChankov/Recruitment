using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Common.Configurations.Identity
{
    /// <summary>
    /// Configurational class for <see cref="SystemUserPassword"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SystemUserPassword}" />
    [ExcludeFromCodeCoverage]
    public sealed class SystemUserPasswordEntityConfiguration : IEntityTypeConfiguration<SystemUserPassword>
    {
        public void Configure(EntityTypeBuilder<SystemUserPassword> builder)
        {
            builder.ToTable("SystemUserPassword", Constants.IDENTITY_SCHEMA);

            builder.HasKey(sup => sup.Id);

            builder.Property(sup => sup.Password).IsRequired().HasMaxLength(50);
            builder.Property(sup => sup.PasswordSalt).IsRequired().HasMaxLength(50);

            // 1:1 relation SystemUser-SystemUsePassword
            builder
                .HasOne(p => p.SystemUser)
                .WithOne(su => su.SystemUserPassword)
                .HasForeignKey<SystemUserPassword>(p => p.SystemUserId);
        }
    }
}

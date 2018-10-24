using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="SystemUserPassword"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{SystemUserPassword}" />
    public sealed class SystemUserPasswordEntityConfiguration : IEntityTypeConfiguration<SystemUserPassword>
    {
        public void Configure(EntityTypeBuilder<SystemUserPassword> builder)
        {
            builder.ToTable("SystemUserPassword");

            builder.HasKey(sup => sup.Id);

            builder.Property(sup => sup.Password).IsRequired().HasMaxLength(50);
            builder.Property(sup => sup.PasswordSalt).IsRequired().HasMaxLength(50);

            builder
                .HasOne(sup => sup.SystemUser)
                .WithMany(sup => sup.SystemUserPasswords)
                .HasForeignKey(sup => sup.SystemUserId);
        }
    }
}

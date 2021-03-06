﻿using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Common.Configurations.Identity
{
    /// <summary>
    /// Configurational class for <see cref="Role"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Role}" />
    [ExcludeFromCodeCoverage]
    public sealed class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role", Constants.IDENTITY_SCHEMA);

            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name).HasMaxLength(60);
            builder.Property(r => r.Code).HasMaxLength(3);
            builder.Property(r => r.Description).HasMaxLength(200);
            builder.HasIndex(r => r.Code).IsUnique();

            // Optional
            builder
                .HasMany(r => r.RoleActionOrganizations)
                .WithOne(rao => rao.Role)
                .HasForeignKey(r => r.RoleId);

            builder
                .HasMany(r => r.SystemUsers)
                .WithOne(su => su.Role)
                .HasForeignKey(su => su.RoleId);

            builder
                .HasMany(r => r.DefaultRoleActions)
                .WithOne(dro => dro.Role)
                .HasForeignKey(dro => dro.RoleId);
        }
    }
}

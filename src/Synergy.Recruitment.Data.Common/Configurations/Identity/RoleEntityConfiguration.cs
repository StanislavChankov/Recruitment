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

            // Optional
            builder
                .HasMany(r => r.RoleActionOrganizations)
                .WithOne(r => r.Role)
                .HasForeignKey(r => r.RoleId);
        }
    }
}
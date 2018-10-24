﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="OrganizationProcess"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{OrganizationProcess}" />
    public sealed class OrganizationProcessConfiguration : IEntityTypeConfiguration<OrganizationProcess>
    {
        /// <summary>
        /// Configures the entity of type <see cref="OrganizationProcess"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<OrganizationProcess> builder)
        {
            builder.ToTable("OrganizationProcess");

            builder.HasKey(x => x.Id);

            builder.Property(pos => pos.Sequence).IsRequired();

            builder
                .HasOne(proc => proc.Process)
                .WithMany(op => op.OrganizationProcesses)
                .HasForeignKey(op => op.ProcessId);
        }
    }
}

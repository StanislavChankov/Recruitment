using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Data.Common.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Process"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Process}" />
    [ExcludeFromCodeCoverage]
    public sealed class ProcessEntityConfiguration : IEntityTypeConfiguration<Process>
    {
        public void Configure(EntityTypeBuilder<Process> builder)
        {
            builder.ToTable("Process");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Description).HasMaxLength(200);

            // Optional
            builder
                .HasMany(proc => proc.OrganizationProcesses)
                .WithOne(op => op.Process)
                .HasForeignKey(op => op.ProcessId);
        }
    }
}

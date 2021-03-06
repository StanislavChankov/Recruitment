﻿using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Data.Common.Configurations
{
    [ExcludeFromCodeCoverage]
    public sealed class InterviewTypeEntityConfiguration : IEntityTypeConfiguration<InterviewType>
    {
        public void Configure(EntityTypeBuilder<InterviewType> builder)
        {
            builder.ToTable("InterviewType");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(200);

            // Optional
            builder
                .HasMany(it => it.Interviews)
                .WithOne(i => i.InterviewType)
                .HasForeignKey(i => i.InterviewTypeId);
        }
    }
}

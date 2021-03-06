﻿using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Common.Configurations.Identity
{
    /// <summary>
    /// Configurational class for <see cref="Person"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Person}" />
    [ExcludeFromCodeCoverage]
    public sealed class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", Constants.IDENTITY_SCHEMA);

            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(60);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(60);
            builder.Property(p => p.EmailAddress).IsRequired().HasMaxLength(60);

            builder.HasIndex(p => p.EmailAddress).IsUnique();

            // 1:1 relation Person - SystemUser
            //builder
            //    .HasOne(p => p.SystemUser)
            //    .WithOne(su => su.Person)
            //    .HasForeignKey<Person>(p => p.SystemUserId);
        }
    }
}

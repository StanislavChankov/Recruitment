﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Country"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Country}" />
    public sealed class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Country"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Country");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);

            // Optional
            builder
                .HasMany(cry => cry.Cities)
                .WithOne(cty => cty.Country)
                .HasForeignKey(cty => cty.CountryId);
        }
    }
}

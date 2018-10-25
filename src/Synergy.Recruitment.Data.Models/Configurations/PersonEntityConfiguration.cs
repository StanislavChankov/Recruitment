using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Person"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Person}" />
    public sealed class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person", Constants.IDENTITY_SCHEMA);

            builder.HasKey(p => p.Id);

            // Optional
            builder
                .HasMany(p => p.SystemUsers)
                .WithOne(p => p.Person)
                .HasForeignKey(p => p.PersonId);
        }
    }
}

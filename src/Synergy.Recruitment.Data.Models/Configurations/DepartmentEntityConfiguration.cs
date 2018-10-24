using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Department"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Department}" />
    public sealed class DepartmentEntityConfiguration : IEntityTypeConfiguration<Department>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Department"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(40);

            // Optional
            builder
                .HasMany(d => d.Positions)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DepartmentId);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Synergy.Recruitment.Data.Models.Configurations
{
    /// <summary>
    /// Configurational class for <see cref="Position"/> entity.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Position}" />
    public sealed class PositionEntityConfiguration : IEntityTypeConfiguration<Position>
    {
        /// <summary>
        /// Configures the entity of type <see cref="Position"/>.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.ToTable("Position");

            builder.HasKey(x => x.Id);

            builder.Property(pos => pos.Name).IsRequired().HasMaxLength(60);
            builder.Property(pos => pos.Description).HasMaxLength(200);

            builder
                .HasOne(pos => pos.Department)
                .WithMany(dep => dep.Positions)
                .HasForeignKey(pos => pos.DepartmentId);

            //Optional
            builder
                .HasMany(p => p.JobAdvertisments)
                .WithOne(ja => ja.Position)
                .HasForeignKey(ja => ja.PositionId);
        }
    }
}

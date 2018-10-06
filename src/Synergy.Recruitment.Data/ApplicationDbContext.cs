using Microsoft.EntityFrameworkCore;

using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Data.Models.Configurations;

namespace Synergy.Recruitment.Data.Data
{
    /// <summary>
    /// The current <see cref="DbContext"/> of the application.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext"/>
    public sealed class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the customers <see cref="DbSet{}"/>.
        /// </summary>
        public DbSet<Technology> Technologies { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder
                .ApplyConfiguration(new TechnologyEntityConfiguration());
    }
}

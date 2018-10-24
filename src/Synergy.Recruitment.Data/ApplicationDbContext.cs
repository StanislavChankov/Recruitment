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

        public DbSet<CandidateCompany> CandidateCompany { get; set; }

        public DbSet<Candidate> Candidate { get; set; }

        public DbSet<CandidateInfo> CandidateInfo { get; set; }

        public DbSet<CandidateJobAdvertisment> CandidateJobAdvertisment { get; set; }

        public DbSet<City> City { get; set; }

        public DbSet<Company> Company { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Interview> Interview { get; set; }

        public DbSet<InterviewType> InterviewType { get; set; }

        public DbSet<JobAdvertisement> JobAdvertisement { get; set; }

        public DbSet<OrganizationProcess> OrganizationProcess { get; set; }

        public DbSet<Position> Position { get; set; }

        public DbSet<Process> Process { get; set; }

        public DbSet<Technology> Technology { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder
                .ApplyConfiguration(new CandidateCompanyEntityConfiguration())
                .ApplyConfiguration(new CandidateEntityConfiguration())
                .ApplyConfiguration(new CandidateInfoEntityConfiguration())
                .ApplyConfiguration(new CandidateJobAdvertismentEntityConfiguration())
                .ApplyConfiguration(new CityEntityConfiguration())
                .ApplyConfiguration(new CompanyEntityConfiguration())
                .ApplyConfiguration(new CountryEntityConfiguration())
                .ApplyConfiguration(new DepartmentEntityConfiguration())
                .ApplyConfiguration(new InterviewEntityConfiguration())
                .ApplyConfiguration(new InterviewTypeEntityConfiguration())
                .ApplyConfiguration(new JobAdvertisementEntityConfiguration())
                .ApplyConfiguration(new OrganizationProcessConfiguration())
                .ApplyConfiguration(new PositionEntityConfiguration())
                .ApplyConfiguration(new ProcessEntityConfiguration())
                .ApplyConfiguration(new TechnologyEntityConfiguration());
    }
}

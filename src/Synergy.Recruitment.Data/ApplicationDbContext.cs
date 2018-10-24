using Microsoft.EntityFrameworkCore;

using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Data.Models.Configurations;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Data
{
    /// <summary>
    /// The current <see cref="DbContext"/> of the application.
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext"/>
    public sealed class ApplicationDbContext : DbContext
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        #endregion

        #region App DbSets

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

        #endregion

        #region Identity DbSets

        public DbSet<Action> Action { get; set; }

        public DbSet<Organization> Organization { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<RoleActionOrganization> RoleActionOrganization { get; set; }

        public DbSet<RoleActionUser> RoleActionUser { get; set; }

        public DbSet<SystemUser> SystemUser { get; set; }

        public DbSet<SystemUserPassword> SystemUserPassword { get; set; }

        #endregion

        #region Protected Methods

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
                .ApplyConfiguration(new TechnologyEntityConfiguration())
                // Identity COnfigurations
                .ApplyConfiguration(new ActionEntityConfiguration())
                .ApplyConfiguration(new OrganizationEntityConfiguration())
                .ApplyConfiguration(new PersonEntityConfiguration())
                .ApplyConfiguration(new RoleEntityConfiguration())
                .ApplyConfiguration(new RoleActionOrganizationEntityConfiguration())
                .ApplyConfiguration(new RoleActionUserEntityConfiguration())
                .ApplyConfiguration(new SystemUserEntityConfiguration())
                .ApplyConfiguration(new SystemUserPasswordEntityConfiguration());

        #endregion
    }
}

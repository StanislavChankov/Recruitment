using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Data.Common.Abstract;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Repositories.Identity
{
    public class OrganizationRepository : EFCoreRepository<Organization>, IOrganizationRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        public OrganizationRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<TResult> GetAsync<TResult>(
            Expression<Func<Organization, bool>> selectExp,
            Expression<Func<Organization, TResult>> projectionExp)
                => Queryable
                    .Where(selectExp)
                    .Select(projectionExp)
                    .SingleOrDefaultAsync();
    }
}

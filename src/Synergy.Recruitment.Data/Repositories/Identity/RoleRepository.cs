using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Data.Common.Abstract;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Models.Identity;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Synergy.Recruitment.Data.Repositories.Identity
{
    public class RoleRepository : EFCoreRepository<Role>, IRoleRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        public RoleRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<TResult> GetAsync<TResult>(
            Expression<Func<Role, bool>> selectExp,
            Expression<Func<Role, TResult>> projectionExp)
                => Queryable
                    .Where(selectExp)
                    .Select(projectionExp)
                    .SingleOrDefaultAsync();
    }
}

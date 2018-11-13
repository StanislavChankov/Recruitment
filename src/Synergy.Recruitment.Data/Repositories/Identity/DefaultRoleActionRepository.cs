using System;
using System.Collections.Generic;
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
    public class DefaultRoleActionRepository : EFCoreRepository<DefaultRoleAction>, IDefaultRoleActionRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        public DefaultRoleActionRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<IEnumerable<TResult>> GetDefaultRoleActionsAsync<TResult>(
            Expression<Func<DefaultRoleAction, bool>> selectExp,
            Expression<Func<DefaultRoleAction, TResult>> projectionExp)
                => ListAsync(selectExp, projectionExp);

        public Task InsertRangeAsync(IEnumerable<DefaultRoleAction> roleActions) => AddRangeAsync(roleActions);
    }
}

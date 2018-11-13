using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Core.Repositories.Identity
{
    public interface IDefaultRoleActionRepository
    {
        /// <summary>
        /// Gets the default role actions across all organization asynchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="selectExp">The select exp.</param>
        /// <param name="projectionExp">The projection exp.</param>
        Task<IEnumerable<TResult>> GetDefaultRoleActionsAsync<TResult>(
            Expression<Func<DefaultRoleAction, bool>> selectExp,
            Expression<Func<DefaultRoleAction, TResult>> projectionExp);

        /// <summary>
        /// Inserts range asynchronously.
        /// </summary>
        /// <param name="roleActions">The role actions.</param>
        Task InsertRangeAsync(IEnumerable<DefaultRoleAction> roleActions);
    }
}

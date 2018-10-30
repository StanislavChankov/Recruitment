using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Core.Repositories.Identity
{
    public interface IPersonRepository
    {
        /// <summary>
        /// Gets the <see cref="TEntityResult"/> by user identifier asynchronously.
        /// </summary>
        /// <typeparam name="TEntityResult">The type of the entity result.</typeparam>
        /// <param name="selectExpr">The select expr.</param>
        /// <param name="projectionExpr">The projection expr.</param>
        Task<TEntityResult> GetByUserIdAsync<TEntityResult>(
            Expression<Func<Person, bool>> selectExpr,
            Expression<Func<Person, TEntityResult>> projectionExpr);
    }
}

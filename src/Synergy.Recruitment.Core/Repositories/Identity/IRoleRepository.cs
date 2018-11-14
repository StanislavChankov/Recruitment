using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Core.Repositories.Identity
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Gets the <see cref="Role"/> <see cref="TResult"/> asynchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="selectExp">The select expression.</param>
        /// <param name="projectionExp">The projection expression.</param>
        Task<TResult> GetAsync<TResult>(
            Expression<Func<Role, bool>> selectExp,
            Expression<Func<Role, TResult>> projectionExp);
    }
}

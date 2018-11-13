using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Core.Repositories.Identity
{
    public interface IOrganizationRepository
    {
        /// <summary>
        /// Gets the <see cref="Organization"/> asynchronously.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="selectExp">The select expression.</param>
        /// <param name="projectionExp">The projection expression.</param>
        Task<TResult> GetAsync<TResult>(
            Expression<Func<Organization, bool>> selectExp,
            Expression<Func<Organization, TResult>> projectionExp);
    }
}

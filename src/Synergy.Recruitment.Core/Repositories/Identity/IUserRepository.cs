using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Core.Repositories.Identity
{
    public interface IUserRepository
    {
        /// <summary>
        /// Gets the <see cref="SystemUser"/> by email and activeness asynchronously.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="isActive">The is active.</param>
        Task<TResult> GetByEmailAsync<TResult>(
            Expression<Func<SystemUser, TResult>> projectionExp,
            Expression<Func<SystemUser, bool>> selectionExp);
    }
}

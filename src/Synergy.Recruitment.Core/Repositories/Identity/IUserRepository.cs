using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Gets the user actions asynchronously.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <param name="projectionExp">The projection exp.</param>
        Task<List<IEnumerable<short>>> GetActionsAsync(
            long userId,
            Expression<Func<SystemUser, IEnumerable<short>>> projectionExp);
    }
}

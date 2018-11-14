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
        /// <param name="selectionExp">The selection expression.</param>
        Task<List<short>> GetActionsAsync(Expression<Func<SystemUser, bool>> selectionExp);

        /// <summary>
        /// Inserts the <see cref="SystemUser"/> asynchronously.
        /// </summary>
        /// <param name="user">The user.</param>
        Task InsertAsync(SystemUser user);
    }
}

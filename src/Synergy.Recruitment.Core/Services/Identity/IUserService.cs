﻿using System.Threading.Tasks;

using Synergy.Recruitment.Business.Models.Users;

namespace Synergy.Recruitment.Core.Services.Identity
{
    public interface IUserService
    {
        /// <summary>
        /// Validates the user credentials asynchronously.
        /// </summary>
        /// <param name="emailAddress">The email address.</param>
        /// <param name="password">The password.</param>
        Task<UserPassword> ValidateCredentialsAsync(string emailAddress, string password);
    }
}

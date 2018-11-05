using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Synergy.Recruitment.Business.Models.Users;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Business.Factories
{
    /// <summary>
    /// The factory class containing static methods for instantiating <see cref="SystemUser"/> related instances.
    /// </summary>
    public static class UserFactory
    {
        /// <summary>
        /// Gets the <see cref="UserPassword"/> out of <see cref="SystemUser"/>.
        /// </summary>
        public static Expression<Func<SystemUser, UserPassword>> GetPersonOrganization
            => user
                => new UserPassword
                {
                    Id = user.Id,
                    PasswordHash = user.SystemUserPassword.Password,
                    PasswordSalt = user.SystemUserPassword.PasswordSalt,
                };


        public static Expression<Func<SystemUser, IEnumerable<short>>> GetActions
            => user
                => user.Role.RoleActionOrganizations
                    .Where(rao => rao.OrganizationId == user.OrganizationId)
                    .Select(rao => rao.Action.ActionEnum);

        public static Expression<Func<SystemUser, bool>> GetUserByEmail(string emailAddress, bool? isActive)
            => user
                => user.Person.EmailAddress == emailAddress 
                    && ((isActive.HasValue && user.Person.IsActive == isActive) || !isActive.HasValue);
    }
}

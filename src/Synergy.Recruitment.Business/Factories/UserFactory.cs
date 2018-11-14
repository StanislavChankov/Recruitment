using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Synergy.Recruitment.Business.Models.Authorization;
using Synergy.Recruitment.Business.Models.Users;
using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Rest.Models.Authorization;

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
                    .Where(rao => user.Person.IsActive
                            && rao.OrganizationId == user.OrganizationId)
                    .Select(rao => rao.Action.ActionEnum);

        public static Expression<Func<SystemUser, bool>> GetUserByEmail(string emailAddress, bool? isActive)
            => user
                => user.Person.EmailAddress == emailAddress
                    && Factory.ProjectIsActive(user.Person.IsActive, isActive);

        public static Expression<Func<SystemUser, bool>> GetUserById(long id, bool? isActive)
            => user
                => user.Id == id
                    && Factory.ProjectIsActive(user.Person.IsActive, isActive);

        public static SystemUserPassword GetUserPassword(
            UserOrganizationInsertRequest userOrg,
            long roleId,
            HashedPassword hashedPass)
                => new SystemUserPassword
                {
                    Password = hashedPass.PasswordHash,
                    PasswordSalt = hashedPass.Salt,
                    SystemUser = new SystemUser
                    {
                        RoleId = roleId,
                        CreatedOnUtc = DateTime.UtcNow,
                        Organization = new Organization
                        {
                            Name = userOrg.OrganizationName,
                        },
                        Person = new Person
                        {
                            EmailAddress = userOrg.Person.EmailAddress,
                            FirstName = userOrg.Person.FirstName,
                            LastName = userOrg.Person.LastName,
                            IsActive = true
                        }
                    }
                };
    }
}

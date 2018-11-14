using System;
using System.Linq.Expressions;

using Synergy.Recruitment.Business.Models.Roles;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Business.Factories
{
    public static class RoleFactory
    {
        /// <summary>
        /// Gets the <see cref="RoleLogic"/> out of <see cref="Role"/>.
        /// </summary>
        public static Expression<Func<Role, RoleLogic>> GetRoleLogic
            => role
                => new RoleLogic
                {
                    RoleId = role.Id,
                    Name = role.Name,
                    Code = role.Code,
                    Description = role.Description,
                    IsActive = role.IsActive
                };

        public static Expression<Func<Role, bool>> GetRoleByCode(string code, bool? isActive)
            => role
                => role.Code == code
                    && Factory.ProjectIsActive(role.IsActive, isActive);
    }
}

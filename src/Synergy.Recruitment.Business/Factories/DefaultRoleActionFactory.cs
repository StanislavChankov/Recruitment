using System;
using System.Linq.Expressions;

using Synergy.Recruitment.Business.Models.RoleActions;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Business.Factories
{
    public static class DefaultRoleActionFactory
    {
        public static Expression<Func<DefaultRoleAction, DefaultRoleActionLogic>> GetBusiness
            => defaultRoleAction
                => new DefaultRoleActionLogic
                {
                    Id = defaultRoleAction.Id,
                    RoleId = defaultRoleAction.RoleId,
                    ActionId = defaultRoleAction.ActionId
                };
    }
}

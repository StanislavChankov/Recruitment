using System.Threading.Tasks;

using Synergy.Recruitment.Business.Models.Roles;

namespace Synergy.Recruitment.Core.Services.Master
{
    public interface IUserRoleService
    {
        /// <summary>
        /// Gets the <see cref="RoleLogic"/> by role code asynchronously.
        /// </summary>
        /// <param name="name">The name.</param>
        Task<RoleLogic> GetByRoleCodeAsync(string name);
    }
}

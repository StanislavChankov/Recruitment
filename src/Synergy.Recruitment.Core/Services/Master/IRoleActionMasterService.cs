using System.Collections.Generic;
using System.Threading.Tasks;

using Synergy.Recruitment.Business.Models.RoleActions;

namespace Synergy.Recruitment.Core.Services.Master
{
    public interface IRoleActionMasterService
    {
        /// <summary>
        /// Gets all default role actions asynchronously.
        /// </summary>
        Task<IEnumerable<DefaultRoleActionLogic>> GetAllDefaultAsync();
    }
}

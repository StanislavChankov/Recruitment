using System.Collections.Generic;
using System.Threading.Tasks;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Models.RoleActions;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services.Master;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Business.Services.Master
{
    public class RoleActionMasterService : IRoleActionMasterService
    {
        private readonly IDefaultRoleActionRepository _defaultRoleActionRepository;

        #region Constructors

        public RoleActionMasterService(IDefaultRoleActionRepository defaultRoleActionRepository)
        {
            _defaultRoleActionRepository = defaultRoleActionRepository;
        }

        #endregion

        public Task<IEnumerable<DefaultRoleActionLogic>> GetAllDefaultAsync()
            => _defaultRoleActionRepository.GetDefaultRoleActionsAsync(
                GenericFactory<DefaultRoleAction>.GetAll,
                DefaultRoleActionFactory.GetBusiness);
    }
}

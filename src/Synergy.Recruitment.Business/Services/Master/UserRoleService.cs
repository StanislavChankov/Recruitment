using System.Threading.Tasks;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Models.Roles;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services.Master;

namespace Synergy.Recruitment.Business.Services.Master
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IRoleRepository _roleRepository;

        #region Constructors

        public UserRoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        #endregion

        public Task<RoleLogic> GetByRoleCodeAsync(string name)
            => _roleRepository.GetAsync(
                RoleFactory.GetRoleByCode(name, default(bool?)),
                RoleFactory.GetRoleLogic);
    }
}

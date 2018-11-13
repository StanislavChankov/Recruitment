using System.Threading.Tasks;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Models.Organizations;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services.Master;

namespace Synergy.Recruitment.Business.Services.Master
{
    public class UserOrganizationService : IUserOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;

        #region Constructors

        public UserOrganizationService(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        #endregion

        public Task<OrganizationLogic> GetByNameAsync(string name)
            => _organizationRepository.GetAsync(
                OrganizationFactory.GetOrganizationByName(name),
                OrganizationFactory.GetOrganizationLogic);
    }
}

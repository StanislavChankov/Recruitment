using System.Threading.Tasks;

using Synergy.Recruitment.Business.Models.Organizations;

namespace Synergy.Recruitment.Core.Services.Master
{
    public interface IUserOrganizationService
    {
        /// <summary>
        /// Gets the <see cref="OrganizationLogic"/> by name asynchronously.
        /// </summary>
        /// <param name="name">The name.</param>
        Task<OrganizationLogic> GetByNameAsync(string name);
    }
}

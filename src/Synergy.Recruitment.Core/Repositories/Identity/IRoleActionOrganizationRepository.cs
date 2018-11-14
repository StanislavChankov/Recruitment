using System.Collections.Generic;
using System.Threading.Tasks;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Core.Repositories.Identity
{
    public interface IRoleActionOrganizationRepository
    {
        Task InsertRangeAsync(IEnumerable<RoleActionOrganization> roleActionOrganization);
    }
}

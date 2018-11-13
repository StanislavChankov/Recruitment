using System.Collections.Generic;
using System.Threading.Tasks;

using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Data.Common.Abstract;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Repositories.Identity
{
    public class RoleActionOrganizationRepository : EFCoreRepository<RoleActionOrganization>, IRoleActionOrganizationRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        public RoleActionOrganizationRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task InsertRangeAsync(IEnumerable<RoleActionOrganization> roleActionOrganization) => AddRangeAsync(roleActionOrganization);
    }
}

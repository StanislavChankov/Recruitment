using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Data.Common.Abstract;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Models.Identity;


namespace Synergy.Recruitment.Data.Repositories.Identity
{
    public class ActionRepository : EFCoreRepository<Action>, IActionRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ActionRepository"/> class.
        /// </summary>
        public ActionRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion
    }
}

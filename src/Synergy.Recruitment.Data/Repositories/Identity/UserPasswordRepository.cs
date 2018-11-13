using System.Threading.Tasks;

using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Data.Common.Abstract;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Repositories.Identity
{
    class UserPasswordRepository : EFCoreRepository<SystemUserPassword>, IUserPasswordRepository
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new instance of the <see cref="UserPasswordRepository"/> class.
        /// </summary>
        public UserPasswordRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task InsertAsync(SystemUserPassword userPassword) => AddAsync(userPassword);
    }
}

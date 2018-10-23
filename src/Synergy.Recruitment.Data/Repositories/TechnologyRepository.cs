using System.Collections.Generic;
using System.Threading.Tasks;

using Synergy.Recruitment.Core.Repositories;
using Synergy.Recruitment.Data.Common.Abstract;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Data.Repositories
{
    /// <summary>
    /// The default implementation of <see cref="ITechnologyRepository"/>.
    /// </summary>
    /// <seealso cref="Synergy.Recruitment.Data.Common.Abstract.EFCoreRepository{Technology}" />
    /// <seealso cref="Synergy.Recruitment.Core.Repositories.ITechnologyRepository" />
    public class TechnologyRepository : EFCoreRepository<Technology>, ITechnologyRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        public TechnologyRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        public Task<IEnumerable<Technology>> GetAllAsync() => ListAsync();

        #endregion
    }
}

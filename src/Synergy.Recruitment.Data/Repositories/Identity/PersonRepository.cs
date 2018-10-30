using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Data.Common.Abstract;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Data.Repositories.Identity
{
    public class PersonRepository : EFCoreRepository<Person>, IPersonRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        public PersonRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion

        #region Public Methods

        public Task<TEntityResult> GetByUserIdAsync<TEntityResult>(
            Expression<Func<Person, bool>> selectExp,
            Expression<Func<Person, TEntityResult>> projectionExp)
                => Queryable
                    .Where(selectExp)
                    .Select(projectionExp)
                    .SingleOrDefaultAsync();

        #endregion
    }
}

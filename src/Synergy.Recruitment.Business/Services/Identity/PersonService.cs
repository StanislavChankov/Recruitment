using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Models.Person;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services.Identity;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Business.Services.Identity
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class.
        /// </summary>
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        #endregion

        public Task<PersonOrganization> GetByUserIdAsync(long userId)
        {
            Expression<Func<Person, bool>> projectionExpression = PersonFactory.GetPersonById(userId);

            return _personRepository.GetByUserIdAsync(projectionExpression, PersonFactory.GetPersonOrganization);
        }
    }
}

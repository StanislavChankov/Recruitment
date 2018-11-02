using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using NSubstitute;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Services.Identity;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Test.Services
{
    [TestClass]
    [TestCategory("Person")]
    public class PersonServiceTests
    {
        private IPersonService _personService;

        private IPersonRepository _personRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _personRepository = Substitute.For<IPersonRepository>();

            _personService = new PersonService(_personRepository);
        }

        [TestMethod]
        public async Task GetByUserIdAsync_CallsRepoWithCorrectArgs()
        {
            var userId = 1;
            var projectionExpression = PersonFactory.GetPersonById(userId);

            var result = await _personService.GetByUserIdAsync(userId);

            await _personRepository
                    .ReceivedWithAnyArgs()
                    .GetByUserIdAsync(projectionExpression, PersonFactory.GetPersonOrganization);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Business.Services.Identity
{
    public class ActionService : IActionService
    {
        private readonly IUserRepository _userRepository;

        public ActionService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BigInteger> GetActiveUserActionsAsync(long userId)
        {
            var actions = await _userRepository.GetActionsAsync(userId, UserFactory.GetActions);
            
            IEnumerable<short> flattedActions = actions.SelectMany(a => a);

            return flattedActions.CalculateActionsInteger();
        }
    }
}

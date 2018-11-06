using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services.Identity;
using Synergy.Recruitment.Resources;

namespace Synergy.Recruitment.Business.Services.Identity
{
    public class ActionService : IActionService
    {
        private readonly IUserRepository _userRepository;

        private readonly IMemoryCache _memoryCache;

        public ActionService(
            IUserRepository userRepository,
            IMemoryCache memoryCache)
        {
            _userRepository = userRepository;
            _memoryCache = memoryCache;
        }

        public Task<BigInteger> GetActiveUserActionsAsync(long userId)
            => _memoryCache.GetOrCreateAsync(
                string.Format(CacheKeys.Actions, userId),
                async entry =>
                {
                    entry.SlidingExpiration = TimeSpan.FromMinutes(10);

                    var actions = await _userRepository.GetActionsAsync(userId, UserFactory.GetActions);

                    IEnumerable<short> flattedActions = actions.SelectMany(a => a);

                    return flattedActions.CalculateActionsInteger();
                });
    }
}

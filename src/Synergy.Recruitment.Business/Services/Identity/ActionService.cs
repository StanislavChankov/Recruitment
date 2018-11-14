using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Numerics;
using System.Threading.Tasks;

using Microsoft.Extensions.Caching.Memory;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services.Identity;
using Synergy.Recruitment.Data.Models.Identity;
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

                    Expression<Func<SystemUser, bool>> selectionExp = UserFactory.GetUserById(userId, default(bool?));

                    IEnumerable<short> actions = await _userRepository.GetActionsAsync(selectionExp);

                    return actions.CalculateActionsInteger();
                });
    }
}

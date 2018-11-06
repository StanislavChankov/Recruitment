using System.Collections.Generic;
using System.Linq;

using NSubstitute;

using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Test.Mocks
{
    public static class ICandidateServiceMockExtensions
    {
        public static void MockGetAllAsync(this ICandidateService candidateService, IEnumerable<Candidate> candidates = null)
            => candidateService
                .GetAllAsync()
                .Returns(candidates ?? Enumerable.Empty<Candidate>());
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Business.Services
{
    public class CandidateService : ICandidateService
    {
        public Task<IEnumerable<Candidate>> GetAllAsync()
            => Task.FromResult(MockFactory.GetCandidates());
    }
}

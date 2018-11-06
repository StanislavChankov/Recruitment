using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Business.Services
{
    public class CandidateService : ICandidateService
    {
        public Task<IEnumerable<Candidate>> GetAllAsync()
            => Task.FromResult(Enumerable.Empty<Candidate>());
    }
}

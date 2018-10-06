using System.Collections.Generic;
using System.Threading.Tasks;
using Synergy.Recruitment.Core.Repositories;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Business.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyService(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }

        public Task<IEnumerable<Technology>> GetAllAsync()
            => _technologyRepository.GetAllAsync();
    }
}

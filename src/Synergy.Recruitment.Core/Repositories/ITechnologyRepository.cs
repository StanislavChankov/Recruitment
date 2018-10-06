using System.Collections.Generic;
using System.Threading.Tasks;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Core.Repositories
{
    public interface ITechnologyRepository
    {
        Task<IEnumerable<Technology>> GetAllAsync();
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;

using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Core.Services
{
    public interface ITechnologyService
    {
        Task<IEnumerable<Technology>> GetAllAsync();
    }
}

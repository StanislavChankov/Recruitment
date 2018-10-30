using System.Threading.Tasks;

using Synergy.Recruitment.Business.Models.Person;

namespace Synergy.Recruitment.Core.Services.Identity
{
    public interface IPersonService
    {
        Task<PersonOrganization> GetByUserIdAsync(long userId);
    }
}

using System.Threading.Tasks;

using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Core.Repositories.Identity
{
    public interface IUserPasswordRepository
    {
        Task InsertAsync(SystemUserPassword userPassword);
    }
}

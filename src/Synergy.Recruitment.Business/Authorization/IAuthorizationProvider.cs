using System.Numerics;
using System.Threading.Tasks;

namespace Synergy.Recruitment.Business.Authorization
{
    public interface IAuthorizationProvider
    {
        Task<BigInteger> GetActionsAsync(long userId);
    }
}

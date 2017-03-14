using System.Security.Claims;
using System.Threading.Tasks;

namespace WebAPI.Auth
{
    public interface IIdentityResolver
    {
        Task<ClaimsIdentity> ResolveIdentity(string username, string email, string unCryptedPassword);
    }
}

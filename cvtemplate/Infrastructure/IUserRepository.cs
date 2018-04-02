using System.Threading.Tasks;
using cvtemplate.Data;

namespace cvtemplate.Infrastructure
{
    public interface IUserRepository
    {
        Task<bool> Update(ApplicationUser user);
        Task SetUserName(ApplicationUser user, string userName);
        Task SetNormalizedUserName(ApplicationUser user, string normalizedName);
        Task<ApplicationUser> FindByName(string normalizedUserName);
        Task<ApplicationUser> FindById(string userId);
        Task<int> Delete(ApplicationUser user);
        Task<int> Create(ApplicationUser user);
        Task SetPasswordHash(ApplicationUser user, string passwordHash);
    }
}
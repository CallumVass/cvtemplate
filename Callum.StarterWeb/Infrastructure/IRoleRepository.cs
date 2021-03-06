using System.Threading.Tasks;
using Callum.StarterWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace Callum.StarterWeb.Infrastructure
{
    public interface IRoleRepository
    {
        Task<string> Create(ApplicationRole role);
        Task<int> Delete(ApplicationRole role);
        Task SetRoleName(ApplicationRole role, string roleName);
        Task SetNormalizedRoleName(ApplicationRole role, string normalizedName);
        Task<ApplicationRole> FindByName(string normalizedRoleName);
        Task<ApplicationRole> FindById(string roleId);
        Task<bool> Update(ApplicationRole role);
    }
}
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace cvtemplate.Infrastructure
{
    public interface IRoleRepository
    {
        Task Create(IdentityRole role);
    }
}
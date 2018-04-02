using System.Threading;
using System.Threading.Tasks;
using cvtemplate.Data;
using Microsoft.AspNetCore.Identity;

namespace cvtemplate.Infrastructure
{
    public class ApplicationRoleStore : IRoleStore<ApplicationRole>
    {
        private readonly IRoleRepository roleRepository;

        public ApplicationRoleStore(IRoleRepository roleRepository)
        {
            this.roleRepository = roleRepository;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            var result = await this.roleRepository.Create(role);

            return !string.IsNullOrEmpty(result)
                    ? IdentityResult.Success
                    : IdentityResult.Failed(new IdentityError { Description = "Failed to create role" });
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            var result = await this.roleRepository.Delete(role);

            return result > 0
                    ? IdentityResult.Success
                    : IdentityResult.Failed(new IdentityError { Description = "Failed to delete role" });
        }

        public async Task<ApplicationRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            return await this.roleRepository.FindById(roleId);
        }

        public async Task<ApplicationRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            return await this.roleRepository.FindByName(normalizedRoleName);
        }

        public async Task<string> GetNormalizedRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await Task.FromResult(role.NormalizedName);
        }

        public async Task<string> GetRoleIdAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await Task.FromResult(role.Id);
        }

        public async Task<string> GetRoleNameAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            return await Task.FromResult(role.Name);
        }

        public async Task SetNormalizedRoleNameAsync(ApplicationRole role, string normalizedName, CancellationToken cancellationToken)
        {
            await this.roleRepository.SetNormalizedRoleName(role, normalizedName);
        }

        public async Task SetRoleNameAsync(ApplicationRole role, string roleName, CancellationToken cancellationToken)
        {
            await this.roleRepository.SetRoleName(role, roleName);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationRole role, CancellationToken cancellationToken)
        {
            var result = await this.roleRepository.Update(role);

            return result
                    ? IdentityResult.Success
                    : IdentityResult.Failed(new IdentityError { Description = "Failed to update role" });
        }

        public void Dispose()
        {

        }
    }
}
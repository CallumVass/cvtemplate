using System.Threading;
using System.Threading.Tasks;
using Callum.StarterWeb.Data;
using Microsoft.AspNetCore.Identity;

namespace Callum.StarterWeb.Infrastructure
{
    public class ApplicationUserStore
        : IUserStore<ApplicationUser>,
            IUserPasswordStore<ApplicationUser>,
            IUserEmailStore<ApplicationUser>
    {
        private readonly IUserRepository userRepository;
        public ApplicationUserStore(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var result = await this.userRepository.Create(user);

            return !string.IsNullOrEmpty(result)
                ? IdentityResult.Success
                : IdentityResult.Failed(new IdentityError() { Description = "Failed to create user" });
        }

        public async Task<IdentityResult> DeleteAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var result = await this.userRepository.Delete(user);

            return result > 0
                ? IdentityResult.Success
                : IdentityResult.Failed(new IdentityError() { Description = "Failed to delete user" });
        }

        public async Task<ApplicationUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var result = await this.userRepository.FindById(userId);

            return result;
        }

        public async Task<ApplicationUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var result = await this.userRepository.FindByName(normalizedUserName);

            return result;
        }

        public async Task<string> GetNormalizedUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.NormalizedUserName);
        }

        public async Task<string> GetUserIdAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Id);
        }

        public async Task<string> GetUserNameAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.UserName);
        }

        public async Task SetNormalizedUserNameAsync(ApplicationUser user, string normalizedName, CancellationToken cancellationToken)
        {
            await this.userRepository.SetNormalizedUserName(user, normalizedName);
        }

        public async Task SetUserNameAsync(ApplicationUser user, string userName, CancellationToken cancellationToken)
        {
            await this.userRepository.SetUserName(user, userName);
        }

        public async Task<IdentityResult> UpdateAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            var result = await this.userRepository.Update(user);

            return result
                ? IdentityResult.Success
                : IdentityResult.Failed(new IdentityError() { Description = "Failed to update user" });
        }

        public async Task SetPasswordHashAsync(ApplicationUser user, string passwordHash, CancellationToken cancellationToken)
        {
            await this.userRepository.SetPasswordHash(user, passwordHash);
        }

        public async Task<string> GetPasswordHashAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.PasswordHash);
        }

        public async Task<bool> HasPasswordAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
        }

        public async Task SetEmailAsync(ApplicationUser user, string email, CancellationToken cancellationToken)
        {
            await this.userRepository.SetEmail(user, email);
        }

        public async Task<string> GetEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.Email);
        }

        public async Task<bool> GetEmailConfirmedAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.EmailConfirmed);
        }

        public async Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed, CancellationToken cancellationToken)
        {
            await this.userRepository.SetEmailConfirmed(user, confirmed);
        }

        public async Task<ApplicationUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            return await this.userRepository.FindByEmail(normalizedEmail);
        }

        public async Task<string> GetNormalizedEmailAsync(ApplicationUser user, CancellationToken cancellationToken)
        {
            return await Task.FromResult(user.NormalizedEmail);
        }

        public async Task SetNormalizedEmailAsync(ApplicationUser user, string normalizedEmail, CancellationToken cancellationToken)
        {
            await this.userRepository.SetNormalizedEmail(user, normalizedEmail);
        }

        public void Dispose()
        {

        }
    }
}
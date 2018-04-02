using System.Threading.Tasks;
using cvtemplate.Data;
using LiteDB;

namespace cvtemplate.Infrastructure
{
    public class LiteDbUserRepository : IUserRepository
    {
        private readonly LiteRepository db;

        public LiteDbUserRepository(string connectionString)
        {
            this.db = new LiteRepository(connectionString);
        }

        public async Task<string> Create(ApplicationUser user)
        {
            var rows = db.Insert(user);
            return await Task.FromResult(rows.AsString);
        }

        public async Task<int> Delete(ApplicationUser user)
        {
            return await Task.FromResult(db.Delete<ApplicationUser>(e => e.Id == user.Id));
        }

        public async Task<ApplicationUser> FindByEmail(string normalizedEmail)
        {
            return await Task.FromResult(db.Query<ApplicationUser>()
                                            .Where(e => e.NormalizedEmail == normalizedEmail)
                                            .FirstOrDefault());
        }

        public async Task<ApplicationUser> FindById(string userId)
        {
            return await Task.FromResult(db.Query<ApplicationUser>()
                                            .Where(e => e.Id == userId)
                                            .FirstOrDefault());
        }

        public async Task<ApplicationUser> FindByName(string normalizedUserName)
        {
            return await Task.FromResult(db.Query<ApplicationUser>()
                                            .Where(e => e.NormalizedUserName == normalizedUserName)
                                               .FirstOrDefault());
        }

        public async Task SetEmail(ApplicationUser user, string email)
        {
            user.Email = email;
            await Task.FromResult(db.Update(user));
        }

        public async Task SetEmailConfirmed(ApplicationUser user, bool confirmed)
        {
            user.EmailConfirmed = confirmed;
            await Task.FromResult(db.Update(user));
        }

        public async Task SetNormalizedEmail(ApplicationUser user, string normalizedEmail)
        {
            user.NormalizedEmail = normalizedEmail;
            await Task.FromResult(db.Update(user));
        }

        public async Task SetNormalizedUserName(ApplicationUser user, string normalizedName)
        {
            user.NormalizedUserName = normalizedName;
            await Task.FromResult(db.Update(user));
        }

        public async Task SetPasswordHash(ApplicationUser user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            await Task.FromResult(db.Update(user));
        }

        public async Task SetUserName(ApplicationUser user, string userName)
        {
            user.UserName = userName;
            await Task.FromResult(db.Update(user));
        }

        public async Task<bool> Update(ApplicationUser user)
        {
            return await Task.FromResult(db.Update(user));
        }
    }
}
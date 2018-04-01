using System.Threading.Tasks;
using cvtemplate.Data;
using LiteDB;

namespace cvtemplate.Infrastructure
{
    public class LiteDbUserRepository : IUserRepository
    {
        private readonly string connectionString;

        public LiteDbUserRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> Create(ApplicationUser user)
        {
            using (var db = new LiteRepository(this.connectionString))
            {
                return await Task.FromResult(db.Insert(user));
            }
        }

        public async Task<int> Delete(ApplicationUser user)
        {
            using (var db = new LiteRepository(this.connectionString))
            {
                return await Task.FromResult(db.Delete<ApplicationUser>(e => e.Id == user.Id));
            }
        }

        public async Task<ApplicationUser> FindById(string userId)
        {
            using (var db = new LiteRepository(this.connectionString))
            {
                return await Task.FromResult(db.Query<ApplicationUser>()
                                                .Where(e => e.Id == userId)
                                                .FirstOrDefault());
            }
        }

        public async Task<ApplicationUser> FindByName(string normalizedUserName)
        {
            using (var db = new LiteRepository(this.connectionString))
            {
                return await Task.FromResult(db.Query<ApplicationUser>()
                                                .Where(e => e.NormalizedUserName == normalizedUserName)
                                                .FirstOrDefault());
            }
        }

        public async Task SetNormalizedUserName(ApplicationUser user, string normalizedName)
        {
            using (var db = new LiteRepository(this.connectionString))
            {
                var dbUser = await this.FindById(user.Id);
                dbUser.NormalizedUserName = normalizedName;
                db.Update(dbUser);
            }
        }

        public async Task SetUserName(ApplicationUser user, string userName)
        {
            using (var db = new LiteRepository(this.connectionString))
            {
                var dbUser = await this.FindById(user.Id);
                dbUser.UserName = userName;
                db.Update(dbUser);
            }
        }

        public async Task<bool> Update(ApplicationUser user)
        {
            using (var db = new LiteRepository(this.connectionString))
            {
                return await Task.FromResult(db.Update(user));
            }
        }
    }
}
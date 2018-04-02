using System.Threading.Tasks;
using cvtemplate.Data;
using LiteDB;
using Microsoft.AspNetCore.Identity;

namespace cvtemplate.Infrastructure
{
    public class LiteDbRoleRepository : IRoleRepository
    {
        private readonly LiteRepository db;

        public LiteDbRoleRepository(LiteRepository repository)
        {
            this.db = repository;
        }

        public async Task<string> Create(ApplicationRole role)
        {
            return await Task.FromResult(db.Insert(role));
        }

        public async Task<int> Delete(ApplicationRole role)
        {
            return await Task.FromResult(db.Delete<ApplicationRole>(e => e.Id == role.Id));
        }

        public async Task<ApplicationRole> FindById(string roleId)
        {
            return await Task.FromResult(db.Query<ApplicationRole>().Where(e => e.Id == roleId).FirstOrDefault());
        }

        public async Task<ApplicationRole> FindByName(string normalizedRoleName)
        {
            return await Task.FromResult(db.Query<ApplicationRole>().Where(e => e.NormalizedName == normalizedRoleName).FirstOrDefault());
        }

        public async Task SetNormalizedRoleName(ApplicationRole role, string normalizedName)
        {
            role.NormalizedName = normalizedName;
            await Task.FromResult(db.Update(role));
        }

        public async Task SetRoleName(ApplicationRole role, string roleName)
        {
            role.Name = roleName;
            await Task.FromResult(db.Update(role));
        }

        public async Task<bool> Update(ApplicationRole role)
        {
            return await Task.FromResult(db.Update(role));
        }
    }
}
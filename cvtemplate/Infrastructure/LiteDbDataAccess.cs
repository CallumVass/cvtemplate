using System.Threading.Tasks;
using cvtemplate.Data;
using LiteDB;

namespace cvtemplate.Infrastructure
{
    public class LiteDbDataAccess : IDataAccess
    {
        private readonly string connectionString;

        public LiteDbDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<int> CreateUser(ApplicationUser user)
        {
            using (var db = new LiteRepository(this.connectionString))
            {
                return await Task.FromResult(db.Insert(user));
            }
        }
    }
}
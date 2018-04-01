using System.Threading.Tasks;
using cvtemplate.Data;

namespace cvtemplate.Infrastructure
{
    public interface IDataAccess
    {
        Task<int> CreateUser(ApplicationUser user);
    }
}
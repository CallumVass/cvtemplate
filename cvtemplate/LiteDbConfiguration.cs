using System.Threading.Tasks;
using cvtemplate.Data;
using cvtemplate.Infrastructure;
using LiteDB;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace cvtemplate
{
    public class LiteDbConfiguration
    {
        private readonly UserManager<ApplicationUser> userManager;

        public LiteDbConfiguration(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public void Init()
        {
            // var mapper = BsonMapper.Global;

            // mapper.Entity<ApplicationUser>()
            //     .Id(e => e.Id);

            // Add a user
            string user = "callum.vass@gmail.com";
            string password = "Qwerty123!";
            this.userManager.CreateAsync(new ApplicationUser
            {
                UserName = user,
                Email = user,
                EmailConfirmed = true
            }, password).Wait();
        }
    }
}

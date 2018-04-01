using System;
using System.Threading.Tasks;
using cvtemplate.Data;
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
            // Add a user
            string user = "callum.vass@gmail.com";
            string password = "qwerty123!";
            Task.FromResult(this.userManager.CreateAsync(new ApplicationUser
            {
                UserName = user,
                Email = user,
                EmailConfirmed = true
            }, password));
        }
    }
}

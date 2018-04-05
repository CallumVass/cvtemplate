using Callum.StarterWeb.Data;
using Callum.StarterWeb.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace Callum.StarterWeb
{
    public class LiteDbConfiguration
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository userRepository;

        public LiteDbConfiguration(UserManager<ApplicationUser> userManager, IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            this.userManager = userManager;
        }

        public void Init()
        {
            // Add a user if doesn't exist
            string email = "callum.vass@gmail.com";
            string password = "Qwerty123!";

            var normalizedEmail = this.userManager.NormalizeKey(email);
            var user = this.userRepository.FindByEmail(normalizedEmail).Result;

            if (user == null)
            {
                this.userManager.CreateAsync(new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    EmailConfirmed = true
                }, password).Wait();
            }
        }
    }
}

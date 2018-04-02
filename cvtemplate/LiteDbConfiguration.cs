using cvtemplate.Data;
using cvtemplate.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace cvtemplate
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

            var user = this.userRepository.FindByEmail(email).Result;

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

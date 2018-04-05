using System.Threading;
using System.Threading.Tasks;
using Callum.StarterWeb.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Callum.StarterWeb.Features.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand>
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        public LoginCommandHandler(SignInManager<ApplicationUser> signInManager)
        {
            this.signInManager = signInManager;
        }

        public async Task Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            await this.signInManager.PasswordSignInAsync(request.Email, request.Password, true, lockoutOnFailure: false);
        }
    }
}
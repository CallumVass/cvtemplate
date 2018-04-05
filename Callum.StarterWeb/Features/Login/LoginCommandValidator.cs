using FluentValidation;

namespace Callum.StarterWeb.Features.Login
{
    public class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(e => e.Email).NotEmpty().WithMessage("Email is required.");
            RuleFor(e => e.Email).EmailAddress().WithMessage("Email must be a valid email address.");
            RuleFor(e => e.Password).NotEmpty().WithMessage("Password is required.");
        }
    }
}
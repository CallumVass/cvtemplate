using FluentValidation;

namespace cvtemplate.Features.Login
{
    public class LoginViewModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class LoginViewModelValidator : AbstractValidator<LoginViewModel>
    {
        public LoginViewModelValidator()
        {
            RuleFor(e => e.Email).NotNull().NotEmpty().WithMessage("Email is required.");
            RuleFor(e => e.Email).EmailAddress().WithMessage("Email must be a valid email address.");
            RuleFor(e => e.Password).NotNull().NotEmpty().WithMessage("Password is required.");
        }
    }
}
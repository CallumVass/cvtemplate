using System.ComponentModel.DataAnnotations;
using MediatR;

namespace cvtemplate.Features.Login
{
    // Have to use data annotations until FluentValidation works in 2.1..
    public class LoginCommand : IRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
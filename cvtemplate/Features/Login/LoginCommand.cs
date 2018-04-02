using System.ComponentModel.DataAnnotations;
using MediatR;

namespace cvtemplate.Features.Login
{
    public class LoginCommand : IRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
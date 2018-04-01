using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace cvtemplate.Features.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand>
    {
        public LoginCommandHandler()
        {

        }

        public Task Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
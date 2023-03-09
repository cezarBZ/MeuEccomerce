using MediatR;
using MeuEccomerce.API.Application.Commands.Orders;

namespace MeuEccomerce.API.Application.CommandHandlers.Orders
{
    public class CreateORderDetailsCommandHandler : IRequestHandler<CreateORderDetailsCommand, bool>
    {
        public Task<bool> Handle(CreateORderDetailsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

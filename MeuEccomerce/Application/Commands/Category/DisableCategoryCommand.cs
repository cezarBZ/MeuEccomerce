using MediatR;

namespace MeuEccomerce.API.Application.Commands.Category
{
    public class DisableCategoryCommand : IRequest<bool>
    {
        public DisableCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; private set; }
    }
}

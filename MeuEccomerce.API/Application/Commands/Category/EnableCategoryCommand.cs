using MediatR;

namespace MeuEccomerce.API.Application.Commands.Category
{
    public class EnableCategoryCommand : IRequest<bool>
    {
        public EnableCategoryCommand(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; set; }
    }
}

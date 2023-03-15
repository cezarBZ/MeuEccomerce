using MediatR;
using MeuEccomerce.API.Application.Query.ShoppingCarts;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

namespace MeuEccomerce.API.Application.QueryHandler.ShoppingCarts
{
    public class GetShoppingCartItemsQueryHandler : IRequestHandler<GetShoppingCartItemsQuery, IReadOnlyList<ShoppingCartItem>>
    {
        private readonly IShoppingCartItemRepository _repository;

        public GetShoppingCartItemsQueryHandler(IShoppingCartItemRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
        }

        public Task<IReadOnlyList<ShoppingCartItem>> Handle(GetShoppingCartItemsQuery request, CancellationToken cancellationToken)
        {
            var shoppingCartItems = _repository.Get(c => c.ShoppingCartId == request.ShoppingCartId).ToList();
            
            return Task.FromResult<IReadOnlyList<ShoppingCartItem>>(shoppingCartItems) ;
        }
    }
}

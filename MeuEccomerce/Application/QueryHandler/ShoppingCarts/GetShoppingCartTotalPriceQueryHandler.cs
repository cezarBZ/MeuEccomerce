using MediatR;
using MeuEccomerce.API.Application.Query.ShoppingCarts;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;

namespace MeuEccomerce.API.Application.QueryHandler.ShoppingCarts
{
    public class GetShoppingCartTotalPriceQueryHandler : IRequestHandler<GetShoppingCartTotalPriceQuery, Decimal>
    {
        private readonly IShoppingCartItemRepository _repository;
        private readonly IProductRepository  _productRepository;

        public GetShoppingCartTotalPriceQueryHandler(IShoppingCartItemRepository repository, IProductRepository productRepository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public  Task<decimal> Handle(GetShoppingCartTotalPriceQuery request, CancellationToken cancellationToken)
        {

            var shoppingCartItems = _repository.Get(c => c.ShoppingCartId == request.ShoppingCartId);

            var total = shoppingCartItems.Select(c => _productRepository.GetById(c.ProductId).Price * c.Quantity).Sum();
            return Task.FromResult(total);
        }
    }
}

using MediatR;
using MeuEccomerce.API.Application.CommandHandlers.Orders;
using MeuEccomerce.API.Application.Commands.Orders;
using MeuEccomerce.API.Application.Query.ShoppingCarts;
using MeuEccomerce.API.Application.Services;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using MeuEccomerce.Domain.AggregatesModel.ShoppingCartAggregate;
using Moq;

namespace MeuEccomerce.Tests.Handlers.Commands.Orders
{

    public class CreateOrderCommandHandlerTest
    {
        private readonly Mock<ShoppingCartService> _shoppingCartServiceMock;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<IOrderRepository> _orderRepositoryMock;
        private readonly CreateOrderCommandHandler _createOrderCommandHandler;

        public CreateOrderCommandHandlerTest()
        {
            _shoppingCartServiceMock = new Mock<ShoppingCartService>();
            _mediatorMock = new Mock<IMediator>();
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _createOrderCommandHandler = new CreateOrderCommandHandler(
                _shoppingCartServiceMock.Object,
                _mediatorMock.Object,
                _orderRepositoryMock.Object
            );
        }

        [Fact]
        public async Task Handle_ShouldCreateOrderSuccessfully()
        {
            // Arrange
            var shoppingCartItems = new List<ShoppingCartItem>()
        {
            new ShoppingCartItem(Guid.NewGuid(), 2, Guid.NewGuid(), 10),
            new ShoppingCartItem(Guid.NewGuid(), 3, Guid.NewGuid(), 10)
        };
            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetShoppingCartItemsQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(shoppingCartItems);
            _mediatorMock
                .Setup(x => x.Send(It.IsAny<GetShoppingCartTotalPriceQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(28.8m);

            var createOrderCommand = new CreateOrderCommand(
            
                "John",
                "Doe",
                "123 Main Street",
                "Apt 4",
                "12345",
                "NY",
                "New York",
                "555-5555",
                "johndoe@example.com",
                DateTime.Now,
                null
            );

            // Act
            var result = await _createOrderCommandHandler.Handle(createOrderCommand, CancellationToken.None);

            // Assert
            _orderRepositoryMock.Verify(x => x.Add(It.IsAny<Order>()), Times.Once);
            _mediatorMock.Verify(x => x.Send(It.IsAny<CreateOrderDetailsCommand>(), It.IsAny<CancellationToken>()), Times.Exactly(shoppingCartItems.Count));
            _orderRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
            Assert.True(result);
        }
    }

}

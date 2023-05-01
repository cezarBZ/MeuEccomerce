using MeuEccomerce.API.Application.CommandHandlers.Orders;
using MeuEccomerce.API.Application.Commands.Orders;
using MeuEccomerce.Domain.AggregatesModel.OrderAggregate;
using Moq;

namespace MeuEccomerce.Tests.Handlers.Commands.Orders
{ 
    public class CreateOrderDetailsCommandHandlerTest
    {
        private readonly Mock<IOrderRepository> _orderRepositoryMock;

        private readonly CreateOrderDetailsCommandHandler _handler;

        public CreateOrderDetailsCommandHandlerTest()
        {
            _orderRepositoryMock = new Mock<IOrderRepository>();
            _handler = new CreateOrderDetailsCommandHandler(_orderRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddOrderDetailsToOrderSuccessfully()
        {
            var orderId = 1;
            var productId = Guid.NewGuid();
            var quantity = 3;
            var price = 4.56m;

            var command = new CreateOrderDetailsCommand(orderId, productId, quantity, price);

            _orderRepositoryMock.Setup(x => x.AddOrderDetails(It.IsAny<OrderDetails>())).Verifiable();

            var result = await _handler.Handle(command, CancellationToken.None);

            _orderRepositoryMock.Verify(x => x.AddOrderDetails(It.IsAny<OrderDetails>()), Times.Once);
            Assert.True(result);
        }
    }
    
}

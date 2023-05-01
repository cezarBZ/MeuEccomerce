using MeuEccomerce.API.Application.CommandHandlers.Products;
using MeuEccomerce.API.Application.Commands.Product;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using Moq;

namespace MeuEccomerce.Tests.Handlers.Commands.Products
{

    public class DeleteProductCommandHandlerTest
    {
        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly DeleteProductCommandHandler _handler;

        public DeleteProductCommandHandlerTest()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _handler = new DeleteProductCommandHandler(_productRepositoryMock.Object);
        }

        [Fact]
        public async Task Handle_ValidCommand_DeletesProduct()
        {
            var productId = Guid.NewGuid();
            var command = new DeleteProductCommand(productId);
            var product = new Product("nome","description", 10, "image.url", 20, DateTime.Now, 2);

            _productRepositoryMock.Setup(x => x.GetById(productId)).Returns(product);
            _productRepositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsNotIn<CancellationToken>())).Returns(Task.FromResult(1));

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result);
            _productRepositoryMock.Verify(x => x.Delete(product), Times.Once);
            _productRepositoryMock.Verify(x => x.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Handle_InvalidCommand_ThrowsArgumentNullException()
        {
            DeleteProductCommand command = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
        }

        [Fact]
        public async Task Handle_ProductNotFound_ThrowsArgumentNullException()
        {
            var productId = Guid.NewGuid();
            var command = new DeleteProductCommand(productId);

            _productRepositoryMock.Setup(x => x.GetById(productId)).Returns((Product)null);

            await Assert.ThrowsAsync<ArgumentNullException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }

}

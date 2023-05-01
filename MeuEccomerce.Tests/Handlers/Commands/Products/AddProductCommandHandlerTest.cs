using MeuEccomerce.API.Application.CommandHandlers.Products;
using MeuEccomerce.API.Application.Commands.Product;
using MeuEccomerce.Domain.AggregatesModel.ProductAggregate;
using Moq;

namespace MeuEccomerce.Tests.Handlers.Commands.Products
{
    public class AddProductCommandHandlerTest
    {
        private readonly Mock<IProductRepository> _mockProductRepository;
        private readonly AddProductCommandHandler _addProductCommandHandler;

        public AddProductCommandHandlerTest()
        {
            _mockProductRepository = new Mock<IProductRepository>();
            _addProductCommandHandler = new AddProductCommandHandler(_mockProductRepository.Object);
        }

        [Fact]
        public async Task Handle_ShouldAddProductSuccessfully()
        {
            var command = new AddProductCommand("Product Name", "Product Description", 10.00M, "product-image.png", 10, 1);
            _mockProductRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsNotIn<CancellationToken>())).Returns(Task.FromResult(1));
            var result = await _addProductCommandHandler.Handle(command, CancellationToken.None);

            _mockProductRepository.Verify(r => r.Add(It.IsAny<Product>()), Times.Once);
            _mockProductRepository.Verify(r => r.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
            Assert.True(result);
        }

        [Fact]
        public async Task Handle_ShouldThrowArgumentNullExceptionWhenRequestIsNull()
        {
            AddProductCommand command = null;

            await Assert.ThrowsAsync<ArgumentNullException>(() => _addProductCommandHandler.Handle(command, CancellationToken.None));
        }
    }
}

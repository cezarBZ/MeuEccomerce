using MeuEccomerce.API.Application.CommandHandlers.Categories;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using Moq;

namespace MeuEccomerce.Tests.Handlers.Commands.Categories
{
    public class CreateCategoryCommandHandlerTests
    {
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public CreateCategoryCommandHandlerTests()
        {
            _mockCategoryRepository = new Mock<ICategoryRepository>();
        }

        [Fact]
        public async Task Handle_WithValidRequest_ShouldAddCategoryAndReturnTrue()
        {
            var handler = new CreateCategoryCommandHandler(_mockCategoryRepository.Object);

            var request = new CreateCategoryCommand("Test Category", "Test Category Description", "https://testimage.com");
            _mockCategoryRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsNotIn<CancellationToken>())).Returns(Task.FromResult(1));

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.True(result);
            _mockCategoryRepository.Verify(repo => repo.Add(It.IsAny<Category>()), Times.Once);
            _mockCategoryRepository.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Handle_WithNullRequest_ShouldThrowArgumentNullException()
        {
            var handler = new CreateCategoryCommandHandler(_mockCategoryRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(null, CancellationToken.None));
        }
    }
}

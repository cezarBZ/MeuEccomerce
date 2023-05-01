using MeuEccomerce.API.Application.CommandHandlers.Categories;
using MeuEccomerce.API.Application.Commands.Category;
using MeuEccomerce.Domain.AggregatesModel.CategoryAggregate;
using Moq;

namespace MeuEccomerce.Tests.Handlers.Commands.Categories
{
    public class DisableCategoryCommandHandlerTests
    {
        private readonly Mock<ICategoryRepository> _mockCategoryRepository;

        public DisableCategoryCommandHandlerTests()
        {
            _mockCategoryRepository = new Mock<ICategoryRepository>();
        }

        [Fact]
        public async Task Handle_WithValidRequest_ShouldDisableCategoryAndReturnTrue()
        {
            var handler = new DisableCategoryCommandHandler(_mockCategoryRepository.Object);
            var categoryId = 1;
            var request = new DisableCategoryCommand(categoryId);

            var category = new Category("TestCategory", "TestCategoryDescription", "https://testimage.com");
            _mockCategoryRepository.Setup(repo => repo.GetByIdAsync(categoryId))
                .ReturnsAsync(category);
            _mockCategoryRepository.Setup(x => x.UnitOfWork.SaveChangesAsync(It.IsNotIn<CancellationToken>())).Returns(Task.FromResult(1));

            var result = await handler.Handle(request, CancellationToken.None);

            Assert.True(result);
            _mockCategoryRepository.Verify(repo => repo.Update(category), Times.Once);
            _mockCategoryRepository.Verify(repo => repo.UnitOfWork.SaveChangesAsync(CancellationToken.None), Times.Once);
        }

        [Fact]
        public async Task Handle_WithInvalidCategoryId_ShouldThrowArgumentNullException()
        {
            var handler = new DisableCategoryCommandHandler(_mockCategoryRepository.Object);
            var categoryId = 1;
            var request = new DisableCategoryCommand(categoryId);

            _mockCategoryRepository.Setup(repo => repo.GetByIdAsync(categoryId))
                .ReturnsAsync((Category)null);

            await Assert.ThrowsAsync<ArgumentNullException>(() => handler.Handle(request, CancellationToken.None));
        }
    }
}

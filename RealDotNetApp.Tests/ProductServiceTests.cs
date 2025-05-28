using Moq;
using RealDotNetApp.Application.Services;
using RealDotNetApp.Domain.Models;
using RealDotNetApp.Infrastructure.Repositories;

namespace RealDotNetApp.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetAllAsync_ReturnsAllProducts()
        {
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                    .ReturnsAsync(new List<Product> { new Product { Id = 1, Name = "Test", Price = 10 } });

            var service = new ProductService(mockRepo.Object);

            var result = await service.GetAllAsync();

            Assert.Single(result);
        }

        [Fact]
        public async Task CreateAsync_ValidProduct_ReturnsProduct()
        {
            var dto = new ProductCreateDto { Name = "Test", Price = 15 };
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.AddAsync(It.IsAny<Product>()))
                    .Returns(Task.CompletedTask);

            var service = new ProductService(mockRepo.Object);
            var result = await service.CreateAsync(dto);

            Assert.Equal(dto.Name, result.Name);
            Assert.Equal(dto.Price, result.Price);
        }
    }
}

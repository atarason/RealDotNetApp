using RealDotNetApp.Application.Interfaces;
using RealDotNetApp.Domain.Models;
using RealDotNetApp.Infrastructure.Repositories;

namespace RealDotNetApp.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository) => _repository = repository;

    /// <inheritdoc/>
    public async Task<IEnumerable<Product>> GetAllAsync() => await _repository.GetAllAsync();

    /// <inheritdoc/>
    public async Task<Product> CreateAsync(ProductCreateDto dto)
    {
        var product = new Product { Name = dto.Name, Price = dto.Price };
        await _repository.AddAsync(product);
        return product;
    }
}

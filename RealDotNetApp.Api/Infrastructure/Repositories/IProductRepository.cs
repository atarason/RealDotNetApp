using RealDotNetApp.Domain.Models;

namespace RealDotNetApp.Infrastructure.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task AddAsync(Product product);
}

using RealDotNetApp.Domain.Models;

namespace RealDotNetApp.Infrastructure.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIDAsync(int id);
    Task AddAsync(Product product);
}

using RealDotNetApp.Domain.Models;

namespace RealDotNetApp.Application.Interfaces;

public interface IProductService
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> CreateAsync(ProductCreateDto dto);
}

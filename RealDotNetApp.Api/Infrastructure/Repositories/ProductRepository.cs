using Microsoft.EntityFrameworkCore;
using RealDotNetApp.Domain.Models;
using RealDotNetApp.Infrastructure.Db;

namespace RealDotNetApp.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;
    public ProductRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Product>> GetAllAsync() => await _context.Products.ToListAsync();

    public async Task<Product> GetByIDAsync(int id) => await _context.Products.SingleOrDefaultAsync(x=>x.Id == id);

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using RealDotNetApp.Domain.Models;

namespace RealDotNetApp.Infrastructure.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
}

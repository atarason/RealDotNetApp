using System.ComponentModel.DataAnnotations;

namespace RealDotNetApp.Domain.Models;

public class ProductCreateDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, double.MaxValue)]
    public decimal Price { get; set; }
}

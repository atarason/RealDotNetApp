// Program.cs — API entry point
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealDotNetApp.Application.Interfaces;
using RealDotNetApp.Application.Services;
using RealDotNetApp.Domain.Models;
using RealDotNetApp.Infrastructure.Db;
using RealDotNetApp.Infrastructure.Repositories;
using Serilog;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("RealAppDb"));

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var key = Encoding.ASCII.GetBytes("supersecretkey1234");
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/api/products", async (IProductService service) =>
{
    var items = await service.GetAllAsync();
    return Results.Ok(items);
}).WithTags("Products");

app.MapGet("/api/products/{id:int}", async (IProductService service, int id) =>
{
    var items = await service.GetByIdAsync(id);
    return Results.Ok(items);
}).WithTags("Products");

app.MapPost("/api/products", async ([FromBody] ProductCreateDto dto, IProductService service) =>
{
    if (string.IsNullOrWhiteSpace(dto.Name) || dto.Price <= 0)
        return Results.BadRequest("Invalid product data.");

    var created = await service.CreateAsync(dto);
    return Results.Created($"/api/products/{created.Id}", created);
}).WithTags("Products");

app.Run();
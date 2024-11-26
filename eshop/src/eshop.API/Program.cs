


using eshop.Application;
using eshop.Application.Contracts;
using eshop.Application.Features.Products.Queries.GetProducts;
using eshop.Infrastructure.Data;
using eshop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<GetProductsRequest>());
builder.Services.AddScoped<IProductRepository, FakeProductRepository>();

var connectionString = builder.Configuration.GetConnectionString("db");
builder.Services.AddDbContext<TKEshopDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var ctxt = services.GetRequiredService<TKEshopDbContext>();
ctxt.Database.EnsureCreated();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

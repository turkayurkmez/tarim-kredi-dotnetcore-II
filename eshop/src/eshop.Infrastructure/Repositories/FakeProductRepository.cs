using eshop.Application.Contracts;
using eshop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Infrastructure.Repositories
{
    public class FakeProductRepository : IProductRepository
    {
        public Task CreateAsync(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Product 1", Price = 10, Description = "Ürün 1 Açıklama", ImageUrl = "testimage" },
                new Product() { Id = 2, Name = "Product 2", Price = 20, Description = "Ürün 2 Açıklama", ImageUrl = "testimage" },
            };

            return await Task.FromResult(products);
        }

        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> SearchByName(string name)
        {
            var products = new List<Product>()
            {
                new Product() { Id = 1, Name = "Product 1", Price = 10, Description = "Ürün 1 Açıklama", ImageUrl = "testimage" },
                new Product() { Id = 2, Name = "Product 2", Price = 20, Description = "Ürün 2 Açıklama", ImageUrl = "testimage" },
            };

            return await Task.FromResult(products);
        }

        public Task UpdateAsync(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}

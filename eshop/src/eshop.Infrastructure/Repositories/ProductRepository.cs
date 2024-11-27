using eshop.Application.Contracts;
using eshop.Domain;
using eshop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Infrastructure.Repositories
{
    public class ProductRepository(TKEshopDbContext dbContext) : IProductRepository
    {
        public async Task CreateAsync(Product entity)
        {
            dbContext.Products.Add(entity);
            await dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var product = dbContext.Products.Find(id);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Product>> SearchByName(string name)
        {
           return await dbContext.Products.Where(x => x.Name.Contains(name)).ToListAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            //entity'nin id değeri 0 ise INSERT
            //entity'nin id değeri 0'dan büyükse UPDATE
            dbContext.Products.Update(entity);

            await dbContext.SaveChangesAsync();
        }
    }
}

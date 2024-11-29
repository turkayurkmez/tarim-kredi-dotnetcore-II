using eshop.Domain;

namespace eshop.Application.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> SearchByName(string name);
    }
}

using eshop.Domain;

namespace eshop.Application
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){ Id = 1, Name = "Product 1", Price=10, Description="Ürün 1 Açıklama", Stock=100, ImageUrl="testimage" },
                new(){ Id = 2, Name = "Product 2", Price=20, Description="Ürün 2 Açıklama", Stock=200, ImageUrl="testimage" },
                new() { Id = 3, Name = "Product 3", Price=30, Description="Ürün 3 Açıklama", Stock=300, ImageUrl="testimage" }
            };
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}

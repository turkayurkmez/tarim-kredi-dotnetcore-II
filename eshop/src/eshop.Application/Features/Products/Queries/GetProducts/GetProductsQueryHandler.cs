using eshop.Application.Contracts;
using eshop.Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.GetProducts
{
    public class GetProductsQueryHandler(IProductRepository repository) : IRequestHandler<GetProductsRequest, GetProductsResponse>
    {
        public async Task<GetProductsResponse> Handle(GetProductsRequest request)
        {
            var products = await repository.GetAllAsync();

            //Manuel Mapping:
            //var productDto = products.Select(p => new ProductDisplayDto
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    Price = p.Price,
            //    Description = p.Description,
            //    ImageUrl = p.ImageUrl
            //});

            var productsDto = products.Adapt<IEnumerable<ProductDisplayDto>>();

           var result = new GetProductsResponse(productsDto, State:"İşlem başarılı", productsDto.Count());
            //return new GetProductsResponse(new List<ProductDisplayDto>()
            //{
            //    new() { Id = 1, Name = "Product 1", Price = 10, Description = "Ürün 1 Açıklama", ImageUrl = "testimage" },
            //    new() { Id = 2, Name = "Product 2", Price = 20, Description = "Ürün 2 Açıklama", ImageUrl = "testimage" },
            //    new() { Id = 3, Name = "Product 3", Price = 30, Description = "Ürün 3 Açıklama", ImageUrl = "testimage" }
            //}, "Success", 3);
            return await Task.FromResult(result);
            
        }

        public async Task<GetProductsResponse> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var products = await repository.GetAllAsync();

            var productsDto = products.Adapt<IEnumerable<ProductDisplayDto>>();

            var result = new GetProductsResponse(productsDto, State: "İşlem başarılı", productsDto.Count());
            return await Task.FromResult(result);
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.GetProducts
{
    //record'un IRequest olduğunu belirtmek için IRequest interface'ini implemente ediyoruz.
    public record GetProductsRequest : IRequest<GetProductsResponse>
    {
    }

    public record GetProductsResponse(IEnumerable<ProductDisplayDto> Products, string? State, int? Count);
    

    public record class ProductDisplayDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
    
        public string? ImageUrl { get; set; }
    }
    
}

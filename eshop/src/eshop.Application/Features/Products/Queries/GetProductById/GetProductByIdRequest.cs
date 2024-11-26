using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdRequest(int Id): IRequest<GetProductByIdResponse>;
    
    public record GetProductByIdResponse(ProductDetailDto Product, bool? IsFounded);

    public record ProductDetailDto(int Id, string Name, decimal? Price, string? Description, string? ImageUrl);
}

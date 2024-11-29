using MediatR;

namespace eshop.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdRequest(int Id) : IRequest<GetProductByIdResponse>;

    public record GetProductByIdResponse(ProductDetailDto Product, bool? IsFounded);

    public record ProductDetailDto(int Id, string Name, decimal? Price, string? Description, string? ImageUrl);
}

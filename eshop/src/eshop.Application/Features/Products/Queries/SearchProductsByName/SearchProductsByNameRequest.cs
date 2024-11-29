using MediatR;

namespace eshop.Application.Features.Products.Queries.SearchProductsByName
{

    public record SearchProductsByNameRequest(string Name) : IRequest<SearchProductsByNameResponse>;

    public record SearchProductsByNameResponse(IEnumerable<ProductSearchDto> Products, string? State, int? Count);


    public record ProductSearchDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public string? ImageUrl { get; set; }
    }

}

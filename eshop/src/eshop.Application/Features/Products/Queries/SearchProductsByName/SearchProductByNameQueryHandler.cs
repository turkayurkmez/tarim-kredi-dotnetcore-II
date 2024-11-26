using eshop.Application.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.SearchProductsByName
{
    internal class SearchProductsByNameQueryHandler(IProductRepository productRepository) : IRequestHandler<SearchProductsByNameRequest, SearchProductsByNameResponse>
    {
        public Task<SearchProductsByNameResponse> Handle(SearchProductsByNameRequest request, CancellationToken cancellationToken)
        {
            var products = productRepository.SearchByName(request.Name);
            var result = products.Adapt<IEnumerable<ProductSearchDto>>();
            return Task.FromResult(new SearchProductsByNameResponse(result, State: "İşlem başarılı", result.Count()));

        }
    }
}

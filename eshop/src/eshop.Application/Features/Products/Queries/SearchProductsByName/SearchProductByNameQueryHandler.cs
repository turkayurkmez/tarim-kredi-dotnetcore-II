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
        public async Task<SearchProductsByNameResponse> Handle(SearchProductsByNameRequest request, CancellationToken cancellationToken)
        {
            var products = await productRepository.SearchByName(request.Name);
            var result = products.Adapt<IEnumerable<ProductSearchDto>>();

            var count = result.Count();
            string state = count > 0 ? $"adında {request.Name} geçen {count} adet ürün bulundu " : $"{request.Name} geçen hiçbir ürün bulunamadı";
            var response = new SearchProductsByNameResponse(result,State:state, count);
            return response;
          

        }
    }
}

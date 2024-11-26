using eshop.Application.Contracts;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Queries.GetProductById
{
    internal class GetProductByIdQueryHandler(IProductRepository repository) : IRequestHandler<GetProductByIdRequest, GetProductByIdResponse>
    {
        public async Task<GetProductByIdResponse?> Handle(GetProductByIdRequest request, CancellationToken cancellationToken)
        {
            var product = await repository.GetByIdAsync(request.Id);
            if (product == null)
            {
                return new GetProductByIdResponse(null, IsFounded:false);

            }

            var productDto = product.Adapt<ProductDetailDto>();
            return new GetProductByIdResponse(productDto,IsFounded:true);
        }
    }
}

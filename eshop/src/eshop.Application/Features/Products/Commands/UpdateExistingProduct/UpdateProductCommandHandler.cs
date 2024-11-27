using eshop.Application.Contracts;
using eshop.Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Commands.UpdateExistingProduct
{
    internal class UpdateProductCommandHandler(IProductRepository productRepository) : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await productRepository.UpdateAsync(product);
            return new UpdateProductCommandResponse();
        }
    }
}

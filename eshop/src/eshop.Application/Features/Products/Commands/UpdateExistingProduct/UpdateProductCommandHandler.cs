using eshop.Application.Contracts;
using eshop.Domain;
using Mapster;
using MediatR;

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

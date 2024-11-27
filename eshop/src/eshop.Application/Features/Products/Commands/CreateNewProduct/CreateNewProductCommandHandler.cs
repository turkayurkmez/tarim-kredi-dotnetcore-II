using eshop.Application.Contracts;
using eshop.Domain;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Commands.CreateNewProduct
{
    internal class CreateNewProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateNewProductCommandRequest, CreateNewProductCommandResponse>
    {
        public async Task<CreateNewProductCommandResponse> Handle(CreateNewProductCommandRequest request, CancellationToken cancellationToken)
        {
            var product = request.Adapt<Product>();
            await repository.CreateAsync(product);
            return new CreateNewProductCommandResponse(product.Id);
        }
    }
}

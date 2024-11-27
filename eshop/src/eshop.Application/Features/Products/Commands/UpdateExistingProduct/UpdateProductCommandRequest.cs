using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Commands.UpdateExistingProduct
{
    public record UpdateProductCommandRequest(int Id, [Required(ErrorMessage ="Ürün adı boş olmaz")]string Name, string? Description, decimal? Price, string? ImageUrl, int? Stock, int? CategoryId) : IRequest<UpdateProductCommandResponse>;

    public record UpdateProductCommandResponse();
   
}

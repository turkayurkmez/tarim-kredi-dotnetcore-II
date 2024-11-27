using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Application.Features.Products.Commands.CreateNewProduct
{
    public record CreateNewProductCommandRequest : IRequest<CreateNewProductCommandResponse>
    {
        [Required(ErrorMessage = "Ürün adı boş olamaz")]

        //[MaxLength(150)]
        public string Name { get; set; }

        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public string? ImageUrl { get; set; }
        public int? Stock { get; set; }

        public int? CategoryId { get; set; }
    }

    public record CreateNewProductCommandResponse(int Id);
}

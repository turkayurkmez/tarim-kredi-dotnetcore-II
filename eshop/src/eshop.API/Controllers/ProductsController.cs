using eshop.Application;
using eshop.Application.Features.Products.Queries.GetProductById;
using eshop.Application.Features.Products.Queries.GetProducts;
using eshop.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController(IMediator mediator) : ControllerBase
    {

        //private readonly ProductService _productService;

        //public ProductsController(ProductService productService)
        //{
        //    _productService = productService;
        //}

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetProducts()
        {
            //var service = new ProductService();
            var request = new GetProductsRequest();
            var products = await mediator.Send(request);

            //
            //var handler = new GetProductsQueryHandler(null);
            //handler.Handle(request)
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetProductByIdRequest(id);
            var result = await mediator.Send(request);
            if (!result.IsFounded.Value)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}

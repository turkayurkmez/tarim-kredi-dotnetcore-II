

using Microsoft.AspNetCore.Authorization;

namespace eshop.API.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize(Roles = "admin,editor")]
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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
    [HttpGet("[action]/{name}")]
    public async Task<IActionResult> Search(string name)
    {
        var request = new SearchProductsByNameRequest(name);
        var result = await mediator.Send(request);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create(CreateNewProductCommandRequest request)
    {
        if (ModelState.IsValid)
        {
            var result = await mediator.Send(request);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, null);
        }
        return BadRequest(ModelState);

    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateProductCommandRequest request)
    {
        if (id == request.Id)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(request);
                return NoContent();
            }

        }
        else
        {
            ModelState.AddModelError("equal", "gelen id ve güncellenecek ürünün id'si farklı!");
        }
        return BadRequest(ModelState);

    }

}

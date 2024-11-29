using MassTransit;
using Messaging.Catalog.Models;
using Messaging.MessageBus;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Messaging.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IPublishEndpoint publishEndpoint) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> DiscountPrice(DiscountProductPriceRequest request)
        {
            //db'de fiyatı güncelle....
            var product = new {Name="mini pc", Price = 10000 };
            var oldPrice = product.Price;
            var newPrice = product.Price * (1-request.Discount);
            var @event = new ProductPriceDiscountedEvent
            {
                ProductPriceDiscountCommand = new ProductPriceDiscountCommand(request.ProductId, request.Discount, oldPrice, newPrice)
            };

            await publishEndpoint.Publish(@event);
            return Ok(new {Info=$"Ürün fiyatında {request.Discount} oranında indirim yaptık  "});
        }
    }
}

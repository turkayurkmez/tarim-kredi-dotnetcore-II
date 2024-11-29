using MassTransit;
using Messaging.MessageBus;

namespace Messaging.Basket.Consumers
{
    public class ProductPriceDiscountedConsumer(ILogger<ProductPriceDiscountedConsumer> logger) : IConsumer<ProductPriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<ProductPriceDiscountedEvent> context)
        {
            var command = context.Message.ProductPriceDiscountCommand;
            logger.LogInformation($"Sepetteki ürün fiyatı güncellendi. Ürün Id: {command.ProductId}, Eski Fiyat: {command.OldPrice}, Yeni Fiyat: {command.NewPrice}");

            return Task.CompletedTask;
        }
    }
}

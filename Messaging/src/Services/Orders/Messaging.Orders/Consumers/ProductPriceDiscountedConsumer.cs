using MassTransit;
using Messaging.MessageBus;

namespace Messaging.Orders.Consumers
{
    public class ProductPriceDiscountedConsumer(ILogger<ProductPriceDiscountedConsumer> logger) : IConsumer<ProductPriceDiscountedEvent>
    {
        public Task Consume(ConsumeContext<ProductPriceDiscountedEvent> context)
        {
           var message = context.Message.ProductPriceDiscountCommand;
          logger.LogInformation($"Ürün fiyatı [SİPARİŞ SERVİSİNDE] güncellendi. Ürün Id: {message.ProductId}, Eski Fiyat: {message.OldPrice}, Yeni Fiyat: {message.NewPrice}");
            return Task.CompletedTask;
        }
    }
}

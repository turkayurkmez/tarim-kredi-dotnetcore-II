namespace Messaging.Catalog.Models
{
    public record DiscountProductPriceRequest
    {
        public int ProductId { get; set; }
        public decimal Discount { get; set; }

    }
}

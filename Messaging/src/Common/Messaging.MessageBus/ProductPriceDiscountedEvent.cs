using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messaging.MessageBus
{
    //olay isimleri geçmiş zaman olmalı
    public record ProductPriceDiscountedEvent
    {
        public ProductPriceDiscountCommand ProductPriceDiscountCommand { get; set; }
    }

    public record ProductPriceDiscountCommand(int ProductId, decimal Discount, decimal? OldPrice, decimal? NewPrice);
}

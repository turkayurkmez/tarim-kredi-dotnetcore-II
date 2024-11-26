using System;
using System.Collections.Generic;

namespace EFReverseEngineering.Models;

public partial class GetStockColorFlag
{
    public string ProductName { get; set; } = null!;

    public decimal? UnitPrice { get; set; }

    public short? UnitsInStock { get; set; }

    public string? ColorState { get; set; }
}

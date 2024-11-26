using System;
using System.Collections.Generic;

namespace EFReverseEngineering.Models;

public partial class VolumeByDate
{
    public int? Year { get; set; }

    public int? Month { get; set; }

    public decimal? Volume { get; set; }
}

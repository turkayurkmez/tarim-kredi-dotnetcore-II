using System;
using System.Collections.Generic;

namespace EFReverseEngineering.Models;

public partial class AllCompany
{
    public string CompanyName { get; set; } = null!;

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string Type { get; set; } = null!;
}

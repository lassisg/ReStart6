using System;
using System.Collections.Generic;

namespace D01_EF6.Models;

public partial class CurrentProductList
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;
}

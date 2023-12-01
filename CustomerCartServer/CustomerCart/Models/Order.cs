using System;
using System.Collections.Generic;

namespace CustomerCartAPI.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public string Product { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual Customer? Customer { get; set; }
}

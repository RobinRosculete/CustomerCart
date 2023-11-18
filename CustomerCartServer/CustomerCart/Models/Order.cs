using System;
using System.Collections.Generic;

namespace CustomerCartModel;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Customer? Customer { get; set; }
}

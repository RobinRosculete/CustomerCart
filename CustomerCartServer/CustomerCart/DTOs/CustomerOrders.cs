using System;
namespace CustomerCartAPI.DTOs;
public class CustomerOrders
{
	
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string? Product { get; set; }

    public DateOnly? OrderDate { get; set; }

    public decimal? OrderAmount { get; set; }

    public decimal? TotalSpent{ get; set; }

}


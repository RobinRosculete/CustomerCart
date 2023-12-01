using System;
namespace CustomerCartAPI.DTOs;

public class OrderUpdate
{

    public string Product { get; set; }

    public DateOnly OrderDate { get; set; }

    public decimal TotalAmount { get; set; }
}



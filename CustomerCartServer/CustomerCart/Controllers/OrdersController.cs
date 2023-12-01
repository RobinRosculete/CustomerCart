using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerCartAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CustomerCartAPI.Models;
using Microsoft.EntityFrameworkCore;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerCartAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly CustomerordersdatabasegoldenContext _db;
        public OrdersController(CustomerordersdatabasegoldenContext db)
        {
            _db = db;
           
        }
        // GET: api/values
        [HttpGet]
        [Route("customer-orders")]
        public IEnumerable<CustomerOrders> Get()
        {
            var customerOrders = (from customer in _db.Customers
                                  join order in _db.Orders on customer.CustomerId equals order.CustomerId
                                  select new CustomerOrders
                                  {
                                      FirstName = customer.FirstName,
                                      LastName = customer.LastName,
                                      Email = customer.Email,
                                      Product = order.Product,
                                      OrderDate = order.OrderDate,
                                      OrderAmount = order.TotalAmount,
                                      TotalSpent= customer.Orders.Sum(t => t.TotalAmount)

                                  }).ToList();
            return customerOrders;
        }
        // GET: api/values
        [HttpGet]
        [Route("order-ids")]
        public IEnumerable<int> GetOrderIDs()
        {
            // Retrieve all order IDs from the Orders table in the database
            var orderIds = _db.Orders.Select(o => o.OrderId).ToList();
            return orderIds;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _db.Orders.FirstOrDefault(o => o.OrderId == id); // Return the order if found
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] OrderUpdate order)
        {
            if (order == null)
            {
                return BadRequest("Invalid order data"); // Return a 400 Bad Request if order is null
            }

            var orderToUpdate = _db.Orders.FirstOrDefault(o => o.OrderId == id);
            if (orderToUpdate != null)
            {
                orderToUpdate.Product = order.Product;
                orderToUpdate.OrderDate = order.OrderDate;
                orderToUpdate.TotalAmount = order.TotalAmount;
                _db.SaveChanges();
                return Ok(orderToUpdate);
            }
            else {
                Console.WriteLine("orderToUpdate is NULL");
                return NotFound("Order not found");
            }
           
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}


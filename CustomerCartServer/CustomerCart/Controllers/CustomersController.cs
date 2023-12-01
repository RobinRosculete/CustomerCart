using Microsoft.AspNetCore.Mvc;
using CustomerCartAPI.Models;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerCartAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerordersdatabasegoldenContext _db;
        public CustomersController(CustomerordersdatabasegoldenContext db)
        {
            _db = db;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _db.Customers.ToList();
        }
        // GET: api/<CountriesController>

        [HttpGet]
        [Route("customer-email")]
        public IEnumerable<string> GetEmail()
        {
            var emails = _db.Customers.Select(customer => customer.Email).ToList();
            return emails;
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _db.Customers.FirstOrDefault(c => c.CustomerId == id); // Return the order if found
        }
    }
}


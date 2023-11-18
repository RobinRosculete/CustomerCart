using Microsoft.AspNetCore.Mvc;
using CustomerCartModel;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerCartAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly CustomerOrdersDatabaseContext _db;
        public CustomersController(CustomerOrdersDatabaseContext db)
        {
            _db = db;
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _db.Customers.ToList();
        }

    }
}


using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CSharp_Advanced.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        // GET: api/customers
        [HttpGet]
        [Route("")]
        public IEnumerable<string> GetAllCustomers()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/customers/5
        [HttpGet]
        [Route("{id}")]
        public string GetCustomerById(int id)
        {
            return "value";
        }

        // GET api/customers/5/orders
        [HttpGet]
        [Route("{id}/orders")]
        public string GetCustomerOrders(int id)
        {
            return "value";
        }

        // POST api/customers
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/customers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/customers/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

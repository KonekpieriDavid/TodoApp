using CustomersDetails.Models;
using Microsoft.AspNetCore.Mvc;
using CustomersDetails.Data;

namespace CustomersDetails.Controllers

{
    [ApiController]

    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerData _customerData;
        
        public CustomerController(CustomerData customerData)
        {
            _customerData = customerData;
          
        }

        [HttpPost]

        public IResult Create(Customer customer)
        {
            _customerData.InsertCustomers(customer);
            return Results.Ok();
        }


        //GET all action
        /*[HttpGet]
        public ActionResult <List<Customer>> GetAll() =>
                CustomerService.GetAll();
               [HttpGet("{CustomerId}")]

        public ActionResult<Customer> Get(int CustomerId)
        {
            var Customer = CustomerService.Get(CustomerId);

            if (Customer == null)
                return NotFound();

            return Customer;
        }
        public ActionResult<Customer> NotFound()
        {
            throw new NotImplementedException();
        }*/

        //POST action
        //  [HttpPost]
        // public IActionResult Create([FromBody] Customer customer)
        // {
        //  Customer.Add(Customer);
        // return CreatedAtAction(nameof(Get), new { CustomerId = Customer.CustomerId }, Customer);
        // }


    }
}

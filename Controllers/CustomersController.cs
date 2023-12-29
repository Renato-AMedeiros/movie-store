using Microsoft.AspNetCore.Mvc;
using renato_movie_store.Filters;
using renato_movie_store.Mappings;
using renato_movie_store.Models.CustomerModel;
using renato_movie_store.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace renato_movie_store.Controllers
{
    [Route("v1/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly CustomerService _customerService;
        public CustomersController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersList([FromQuery] CustomerFilter filter)
        {
            var resultCustomerList = await _customerService.GetCustomersList(filter);

            var response = resultCustomerList.Select(CustomerMapping.CustomerMap).ToList();

            return Ok(resultCustomerList);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] string customerId)
        {
            var customerById = await _customerService.GetCustomerById(customerId);

            var response = CustomerMapping.CustomerMap(customerById);

            return Ok(response);
        }

        [HttpGet("{customerName}")]
        public async Task<IActionResult> GetCustomerName([FromRoute] string customerName, bool searchByInitial = false)
        {
            var customer = await _customerService.GetCustomersByName(customerName, searchByInitial);

            var response = customer.Select(CustomerMapping.CustomerMap).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequestModel model)
        {
            var createCustomer = await _customerService.CreateCustomer(model);

            var result = CustomerMapping.CustomerMap(createCustomer);

            return Ok(result);
        }

        [HttpPut("{customerid}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerModel model, string customerId)
        {
            var customer = await _customerService.UpdateCustomer(model, customerId);

            var result = CustomerMapping.CustomerMap(customer);

            return Ok(result);
        }

        [HttpDelete("{cusotmerid}")]
        public async Task<IActionResult> DeleteCustomer(string customerId)
        {
            await _customerService.DeleteCustomer(customerId);
            return NoContent();
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using renato_movie_store.Mappings;
using renato_movie_store.Models.CustomerModel;
using renato_movie_store.Services;

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

        [HttpGet("list")]
        public async Task<IActionResult> GetCustomersList()
        {
            var resultCustomerList = await _customerService.GetCustomersList();

            var response = resultCustomerList.Select(CustomerMapping.CustomerMap).ToList();

            return Ok(resultCustomerList);
        }

        [HttpGet("id/{customerId}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] Guid customerId)
        {
            var customerById =  _customerService.GetCustomerById(customerId);

            var response = CustomerMapping.CustomerMap(customerById);

            return Ok(response);
        }

        [HttpGet("name/{customerName}")]
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

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerRequestModel model, Guid customerId)
        {
            var customer = await _customerService.UpdateCustomer(model, customerId);

            var result = CustomerMapping.CustomerMap(customer);

            return Ok(result);
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer ([FromRoute] Guid customerId)
        {
            await _customerService.DeleteCustomer(customerId);
            return NoContent();
        }
    }
}

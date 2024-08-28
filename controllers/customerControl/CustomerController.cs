using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinancialServices.dtos.customerDto;
using FinancialServices.interfaces.ICustomerRepo;
using Microsoft.AspNetCore.Mvc;

namespace FinancialServices.controllers.customerControl
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost("CreateNewCustomer")]

        public async Task<IActionResult> Create([FromBody] CustomerDto customerDto)
        {
            try
            {
                var customer = await _customerRepository.CreateCustomerAsync(customerDto);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                
                return BadRequest(new{status = "failed", message = "cannot create customer account", ex});
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCustomer([FromRoute] Guid Id)
        {
            try
            {
                var customer = await _customerRepository.DeleteByIdAsync(Id);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                
                return BadRequest(new{status = "failed", message = "failed operation", ex});
            }
        }

        [HttpGet("GetCustomers")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var customers = await _customerRepository.GetAllCustomersAsync();
                return Ok(customers);
            }
            catch (System.Exception)
            {
                
                return BadRequest(new{status = "failed", message = "failed to get customers"});
            }
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomersById(Guid customerId)
        {
            try
            {
                var customer = await _customerRepository.GetCustomerByIdAsync(customerId);
                return Ok(customer);
            }
            catch (Exception)
            {
                
                return BadRequest(new{status = "failed", message ="cannot perform this operation"});
            }
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> EditCustomer([FromBody] CustomerDto customerDto, [FromRoute] Guid customerId)
        {
            try
            {
                var customer =await _customerRepository.UpdateCustomerAsync(customerId, customerDto);
                return Ok(customer);
            }
            catch (System.Exception)
            {
                
                return BadRequest(new{status = "failed", message = "failed to update customer"});
            }
        }

    }
}
using Microsoft.AspNetCore.Mvc;
using StoreX.Application.Interfaces;
using StoreX.Domain.Entities;

namespace StoreX.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet(Name = "FetchAllCustomer")]
        [ProducesResponseType(typeof(IEnumerable<Customer>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> FetchAllCustomer(CancellationToken cancellationToken)
        {
            var data = await _customerService.GetAllAsync(cancellationToken);
            if (data == null)
                return NotFound();
            return Ok(data);
        }

        [HttpGet("{id:int}", Name = "GetCustomerById")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetByIdAsync(id, cancellationToken);
            if (customer == null)
                return NotFound($"No se encontró un cliente con ID {id}");
            return Ok(customer);
        }

        [HttpPost(Name = "CreateCustomer")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> CreateCustomer(Customer customer, CancellationToken cancellationToken)
        {
            var created = await _customerService.AddAsync(customer, cancellationToken);
            return Ok(created);
        }

        [HttpPut("{id:int}", Name = "UpdateCustomer")]
        [ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer, CancellationToken cancellationToken)
        {
            customer.CustomerId = id;
            var updated = await _customerService.UpdateAsync(customer, cancellationToken);
            if (updated == null)
                return NotFound($"No se encontró un cliente con ID {id}");
            return Ok(updated);
        }

        [HttpDelete("{id:int}", Name = "DeleteCustomer")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status499ClientClosedRequest)]
        public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            var deleted = await _customerService.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return NotFound($"No se encontró un cliente con ID {id}");
            return Ok(true);
        }
    }
}

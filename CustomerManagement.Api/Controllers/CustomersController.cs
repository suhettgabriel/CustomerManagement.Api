using CustomerManagement.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            if (command == null)
                return BadRequest("Invalid customer data.");

            var result = await _mediator.Send(command);
            return result ? Ok("Customer created successfully.") : BadRequest("Error creating customer.");
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _mediator.Send(new GetCustomerQuery());
            return Ok(result);
        }
    }
}

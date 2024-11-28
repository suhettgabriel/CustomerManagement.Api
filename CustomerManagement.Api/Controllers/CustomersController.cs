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
        /// <summary>
        /// Cadastra cliente
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
        {
            if (command == null)
                return BadRequest("Invalid customer data.");

            var result = await _mediator.Send(command);
            return result ? Ok("Customer created successfully.") : BadRequest("Error creating customer.");
        }

        /// <summary>
        /// Busca lista de cadastro de clientes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _mediator.Send(new GetCustomerQuery());
            return Ok(result);
        }

        /// <summary>
        /// Atualiza cadastro de cliente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerCommand command)
        {
            if (id != command.CustomerId)
                return BadRequest("Customer ID mismatch.");

            var result = await _mediator.Send(command);
            return result ? Ok("Customer updated successfully.") : BadRequest("Error updating customer.");
        }

        /// <summary>
        /// Excluir cadastro por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _mediator.Send(new DeleteCustomerCommand { CustomerId = id });
            return result ? Ok("Customer deleted successfully.") : BadRequest("Error deleting customer.");
        }

    }
}

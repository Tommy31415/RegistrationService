using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using RegistrationService.Handlers;

namespace RegistrationService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegistrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegistrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            return await ExecuteRequest(new GetCustomersRequest());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCustomerCommand command)
        {
            if (ModelState.IsValid)
                return await ExecuteCommand(command);

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return await ExecuteRequest(new DeleteRequest(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, RegisterCustomerCommand command)
        {
            return await ExecuteRequest(new UpdateRegistrationRequest(id,command));
        }

        private async Task<IActionResult> ExecuteCommand(INotification command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        private async Task<IActionResult> ExecuteRequest<T>(IRequest<T> request)
        {
            var result = await _mediator.Send(request);
            return Ok(result);
        }

    }
}

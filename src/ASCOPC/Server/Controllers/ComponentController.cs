using ASCOPC.Domain.Contracts;
using ASOPC.Application.Features.Components.Commands.Delete;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ASCOPC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) =>
            Ok(await _mediator.Send(new DeleteComponentCommand { Id = id }));
    }
}

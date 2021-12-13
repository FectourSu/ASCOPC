using ASOPC.Application.Features.Components.Commands.Create;
using ASOPC.Application.Features.Components.Commands.Delete;
using ASOPC.Application.Features.Components.Commands.Update;
using ASOPC.Application.Features.Components.Queries;
using ASOPC.Application.Features.Components.Queries.Get;
using ASOPC.Application.Features.Components.Queries.GetAll;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IResult = ASCOPC.Domain.Contracts.IResult;
namespace ASCOPC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Editor")]
    public class ComponentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ComponentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IResult>> Delete(int id) =>
            Ok(await _mediator.Send(new DeleteComponentCommand { Id = id }));

        [HttpPost]
        public async Task<ActionResult<IResult>> Create([FromBody] CreateComponentCommand request) =>
            Ok(await _mediator.Send(request));

        [HttpPut]
        public async Task<ActionResult<IResult>> Put([FromBody] UpdateComponentCommand request) =>
            Ok(await _mediator.Send(request));

        [HttpGet]
        public async Task<ActionResult<IResult>> GetAll() =>
            Ok(await _mediator.Send(new GetAllComponentCommand()));
        
        [Authorize(Roles = "User")]
        [HttpGet("{id}")]
        public async Task<ActionResult<IResult>> GetById(int id) =>
            Ok(await _mediator.Send(new GetComponentCommand() { Id = id }));

        [Authorize(Roles = "User")]
        [HttpGet, Route("filter/")]
        public async Task<ActionResult<IResult>> GetFiltered([FromBody] GetFilteredComponentCommand components) =>
            Ok(await _mediator.Send(components));
    }
}

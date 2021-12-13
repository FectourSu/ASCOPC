using ASOPC.Application.Features.Builds.Commands.Create;
using ASOPC.Application.Features.Builds.Commands.Update;
using ASOPC.Application.Features.Builds.Queries.Get;
using ASOPC.Application.Features.Builds.Queries.GetAll;
using ASOPC.Application.Features.Builds.Queries.GetUserBuilds;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASCOPC.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Editor, User")]
    public class BuildsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BuildsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IResult>> Get(int id) =>
            Ok(await _mediator.Send(new GetBuildCommand { Id = id }));

        [HttpGet, Route("[action]/{userId}")]
        public async Task<ActionResult<IResult>> GetUserBuild(string userId) =>
            Ok(await _mediator.Send(new GetUserBuildsCommand() { UserId = userId }));

        [HttpGet]
        public async Task<ActionResult<IResult>> GetAll() =>
            Ok(await _mediator.Send(new GetAllBuildCommand()));

        [HttpPost]
        public async Task<ActionResult<IResult>> Add([FromBody] CreateBuildCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPut]
        public async Task<ActionResult<IResult>> Put([FromBody] UpdateBuildCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete("{id}")]
        public async Task<ActionResult<IResult>> Delete(int id) =>
            Ok(await _mediator.Send(new DeleteBuildCommand { Id = id }));
    }
}

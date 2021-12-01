using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCOPC.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BuildsController : ControllerBase
    {
        private readonly IBuildsService _buildsService;
        public BuildsController(IBuildsService buildsService)
        {
            _buildsService = buildsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IResult>> Get(int id) =>
            Ok(await _buildsService.GetAsync(id));

        [HttpGet]
        public async Task<ActionResult<IResult>> Get() =>
            Ok(await _buildsService.GetAllAsync());

        [HttpPost]
        public async Task<ActionResult<IResult>> Add([FromBody]BuildsDTO builds) =>
            Ok(await _buildsService.InsertAsync(builds));

        [HttpPut]
        public async Task<ActionResult<IResult>> Update([FromBody] BuildsDTO builds, int id) =>
            Ok(await _buildsService.UpdateAsync(builds, id));

        [HttpDelete("{id}")]
        public async Task<ActionResult<IResult>> Delete(int id) =>
            Ok(await _buildsService.DeleteAsync(id));
    }
}

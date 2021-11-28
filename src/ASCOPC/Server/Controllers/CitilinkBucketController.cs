using ASOPC.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using IResult = ASCOPC.Domain.Contracts.IResult;

namespace ASCOPC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitilinkBucketController : ControllerBase
    {
        private readonly ICitilinkBucketService _service;

        public CitilinkBucketController(ICitilinkBucketService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<ActionResult<IResult>> FillComponentItem([FromBody]IEnumerable<int> codeProduct) =>
            Ok(await _service.Add(codeProduct));
    }
}

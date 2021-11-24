using ASCOPC.Infrastructure.Services;
using ASOPC.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASCOPC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillComponentsController : ControllerBase
    {

        //private readonly IFillComponentProvider _provider;

        //public FillComponentsController(IFillComponentProvider provider)
        //{
        //    _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        //}

        //[HttpPost]
        //public async Task<ActionResult<IResult<ComponentsDTO>>> FillComponentItem([FromQuery] string url) =>
        //    Ok(await _provider.FillComponentItem(url));

        private readonly IParserService _service;

        public FillComponentsController(IParserService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Domain.Contracts.IResult>> FillComponentItem()
        {
            ///todo incapsulate
            List<int> links = new()
            {
                1469012,
                1105049,
                1078120
            };
            CitilinkBucketService client = new();
            return Ok(await client.Add(links));
        }
    }
}

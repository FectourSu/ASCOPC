using ASCOPC.Domain.Contracts;
using ASCOPC.Infrastructure.Services;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Providers;
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

        [HttpPost]
        public async Task<ActionResult<HttpResponseMessage>> FillComponentItem([FromQuery] string code)
        {
            HttpClient client = new();
            return await client.GetAsync($"https://www.citilink.ru/basket/add/product/{code}");
        }
    }
}

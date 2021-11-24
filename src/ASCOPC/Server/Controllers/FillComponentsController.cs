using ASCOPC.Domain.Contracts;
using ASCOPC.Infrastructure.Parser;
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

        [HttpGet]
        public async Task<ActionResult<string>> FillComponentItem()
        {
            List<string> links = new() 
            {
                "https://www.citilink.ru/basket/add/product/1469012",
                "https://www.citilink.ru/basket/add/product/1105049",
                "https://www.citilink.ru/basket/add/product/1078120"
            };
            foreach (var link in links)
            {
                HtmlLoader client = new(link);
                await client.GetSource();
            }
            return Ok();
        }
    }
}

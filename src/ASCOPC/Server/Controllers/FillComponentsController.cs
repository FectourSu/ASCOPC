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

   }
}

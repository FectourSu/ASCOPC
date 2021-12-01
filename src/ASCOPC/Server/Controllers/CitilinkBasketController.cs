using ASOPC.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using IResult = ASCOPC.Domain.Contracts.IResult;

namespace ASCOPC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitilinkBasketController : ControllerBase
    {
        private readonly ICitilinkBasketService _service;

        public CitilinkBasketController(ICitilinkBasketService service)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpPost]
        public async Task<ActionResult<IResult>> PushBasket([FromBody]IEnumerable<int> codeProduct) =>
            Ok(await _service.Add(codeProduct));
    }
}

using ASCOPC.Domain.Contracts;
using ASCOPC.Infrastructure.Services;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Provider;
using ASOPC.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASCOPC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin, Editor")]
    public class FillComponentsController : ControllerBase
    {

        private readonly IFillComponentProvider _provider;

        public FillComponentsController(IFillComponentProvider provider)
        {
            _provider = provider ?? throw new ArgumentNullException(nameof(provider));
        }

        [HttpPost]
        public async Task<ActionResult<IResult<ComponentsDTO>>> FillComponentItem([FromQuery] string url) =>
            Ok(await _provider.FillComponent(url));

    }
}

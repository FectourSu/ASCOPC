using ASCOPC.Infrastructure.Parser.Citilink;
using ASCOPC.Infrastructure.Services;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ASCOPC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillComponentsController : ControllerBase
    {
        
        private readonly ParserService _parser;
        public FillComponentsController(ParserService parser)
        {
            _parser = parser; 
        }
        [HttpPost]
        public async Task<ActionResult<OperationResult<ComponentsDTO>>> FillComponentItem()
        {
            var type = "product/materinskaya-plata-asrock-a320m-dvs-r4-0-socketam4-amd-a320-matx-ret-1120710/";
            _parser.ParseItem(new CitilinkParserSetting(type), type); 

            return Ok();
        }
    }
}

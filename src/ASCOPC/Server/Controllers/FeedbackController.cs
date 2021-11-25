using ASCOPC.Shared.Requests;
using ASOPC.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASCOPC.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IEmailService _service;

        public FeedbackController(IEmailService service)
        {
            _service = service ?? throw new ArgumentException(nameof(service));
        }

        [HttpPost]
        public async Task<ActionResult<IResult>> SendMessage([FromBody]MessageRequest message) =>
            Ok(await _service.SendMessage(message).ConfigureAwait(true));
    }
}

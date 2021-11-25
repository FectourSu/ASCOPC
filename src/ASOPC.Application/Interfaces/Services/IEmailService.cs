using ASCOPC.Domain.Contracts;
using ASCOPC.Shared.Requests;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IEmailService
    {
        Task<IResult> SendMessage(MessageRequest request);
    }
}

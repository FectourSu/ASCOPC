using ASCOPC.Domain.Contracts;
using ASCOPC.Shared.DTO;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IParserService
    {
        Task<ComponentsDTO> ParseItem(string url);
    }
}

using ASCOPC.Domain.Contracts;
using ASCOPC.Shared.DTO;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IParserService
    {
        Task<ComponentsDTO> ParseProductItem(string url);
        Task<ComponentsDTO> ParseItem(string url);
    }
}

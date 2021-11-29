using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Interfaces;
using ASCOPC.Shared.DTO;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IComponentService
    {
        Task<IResult<ComponentsDTO>> Get(int id);
        Task<IResult<ComponentsDTO>> Insert(ComponentsDTO components);
        Task<IResult<ComponentsDTO>> Update(ComponentsDTO components);
        Task<IResult<ComponentsDTO>> Delete(int id);
    }
}

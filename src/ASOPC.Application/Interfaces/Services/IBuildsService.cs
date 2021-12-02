using ASCOPC.Domain.Contracts;
using ASCOPC.Shared.DTO;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IBuildsService
    {
        Task<IResult<BuildsDTO>> GetAsync(int id);
        Task<IResult<IEnumerable<BuildsDTO>>> GetAllAsync();
        Task<IResult> InsertAsync(BuildsComponentsDTO build);
        Task<IResult> UpdateAsync(BuildsComponentsDTO build, int id);
        Task<IResult> DeleteAsync(int id);
    }
}

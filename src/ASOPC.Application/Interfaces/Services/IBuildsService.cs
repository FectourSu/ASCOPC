using ASCOPC.Domain.Contracts;
using ASCOPC.Shared.DTO;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IBuildsService
    {
        Task<IResult<BuildsDTO>> GetAsync(int id);
        Task<IResult<IEnumerable<BuildsDTO>>> GetAllAsync();
        Task<IResult> InsertAsync(BuildsDTO build);
        Task<IResult> UpdateAsync(BuildsDTO build, int id);
        Task<IResult> DeleteAsync(int id);
    }
}

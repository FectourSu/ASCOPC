using ASCOPC.Domain.Contracts;
using ASOPC.Application.Features.Builds.Commands.Create;
using ASOPC.Application.Features.Builds.Commands.Update;
using ASOPC.Application.Features.Builds.Queries.Get;

namespace ASOPC.Application.Interfaces.Services
{
    public interface IBuildsService
    {
        Task<IResult<GetBuildResponse>> GetAsync(int id);
        Task<IResult<IEnumerable<GetBuildResponse>>> GetAllAsync();
        Task<IResult> InsertAsync(CreateBuildCommand build);
        Task<IResult<IEnumerable<GetBuildResponse>>> GetUserBuildAsync(string userId);
        Task<IResult> UpdateAsync(UpdateBuildCommand build);
        Task<IResult> DeleteAsync(int id);
    }
}

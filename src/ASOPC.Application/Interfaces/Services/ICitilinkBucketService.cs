using ASCOPC.Domain.Contracts;

namespace ASOPC.Application.Interfaces.Services
{
    public interface ICitilinkBucketService
    {
        Task<IResult> Add(List<int> codes);
    }
}

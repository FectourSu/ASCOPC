using ASCOPC.Domain.Contracts;

namespace ASOPC.Application.Interfaces.Services
{
    public interface ICitilinkBasketService
    {
        Task<IResult> Add(IEnumerable<int> codes);
    }
}

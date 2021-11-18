using ASCOPC.Domain.Contracts;
using ASCOPC.Shared.DTO;

namespace ASOPC.Application.Interfaces.Providers
{
    public interface IFillComponentProvider<TEntity>
        where TEntity : class
    {
        Task<IResult<TEntity>> FillComponent(string url);
    }
}

using ASCOPC.Domain.Contracts;

namespace ASOPC.Application.Interfaces.Provider
{
    public interface IFillComponentProvider<TEntity>
        where TEntity : class
    {
        Task<IResult<TEntity>> FillComponent(string url);
    }
}

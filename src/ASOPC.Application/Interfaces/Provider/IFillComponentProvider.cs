using ASCOPC.Domain.Contracts;

namespace ASOPC.Application.Interfaces.Provider
{
    public interface IFillComponentProvider
    {
        Task<IResult> FillComponent(string url);
    }
}

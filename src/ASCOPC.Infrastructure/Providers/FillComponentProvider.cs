using ASCOPC.Domain.Contracts;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Providers;
using ASOPC.Application.Interfaces.Services;

namespace ASCOPC.Infrastructure.Providers
{
    public class FillComponentProvider : IFillComponentProvider<ComponentsDTO>
    {
        private readonly IParserService _serviceProvider;

        public FillComponentProvider()
        {

        }

        public Task<IResult<ComponentsDTO>> FillComponent(string url)
        {
            throw new NotImplementedException();
        }
    }
}

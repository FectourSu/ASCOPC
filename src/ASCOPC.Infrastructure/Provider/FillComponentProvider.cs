using ASCOPC.Domain.Contracts;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Features.Components.Commands.Create;
using ASOPC.Application.Interfaces.Provider;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace ASCOPC.Infrastructure.Provider
{
    public class FillComponentProvider : IFillComponentProvider
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IParserService _parser;
        public FillComponentProvider(IParserService parser, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            _parser = parser;
        }

        public async Task<IResult> FillComponent(string url)
        {
            var resultBuilder = OperationResult<ComponentsDTO>.CreateBuilder();

            var item = await _parser.ParseItem(url);
            var command = _mapper.Map<CreateComponentCommand>(item);
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                resultBuilder.AppendErrors(result.Errors);

            return resultBuilder.BuildResult();
        }
    }
}

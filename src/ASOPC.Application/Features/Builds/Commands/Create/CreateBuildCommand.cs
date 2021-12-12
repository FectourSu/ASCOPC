using ASCOPC.Domain.Contracts;
using ASOPC.Application.Interfaces.Data;
using ASOPC.Application.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace ASOPC.Application.Features.Builds.Commands.Create
{
    public class CreateBuildCommand : BuildCommand
    {
        public class CreateBuildsHandler : IRequestHandler<CreateBuildCommand, IResult>
        {
            private readonly IBuildsService _buildsService;

            public CreateBuildsHandler(IBuildsService buildService)
            {
                _buildsService = buildService;
            }
            public async Task<IResult> Handle(CreateBuildCommand request, CancellationToken cancellationToken) =>
                await _buildsService.InsertAsync(request);
        }
    }
}

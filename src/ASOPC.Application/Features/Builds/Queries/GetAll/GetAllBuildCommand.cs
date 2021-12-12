using ASCOPC.Domain.Contracts;
using ASOPC.Application.Features.Builds.Queries.Get;
using ASOPC.Application.Features.Builds.Queries.GetUserBuilds;
using ASOPC.Application.Interfaces.Services;
using MediatR;

namespace ASOPC.Application.Features.Builds.Queries.GetAll
{
    public class GetAllBuildCommand : IRequest<IResult<IEnumerable<GetBuildResponse>>>
    {
        public GetAllBuildCommand()
        {
        }

        public class GetAllBuildHandler : IRequestHandler<GetAllBuildCommand,
            IResult<IEnumerable<GetBuildResponse>>>
        {
            private readonly IBuildsService _buildsService;
            public GetAllBuildHandler(IBuildsService buildsService)
            {
                _buildsService = buildsService;
            }

            public async Task<IResult<IEnumerable<GetBuildResponse>>> Handle(GetAllBuildCommand request, 
                CancellationToken cancellationToken) =>
                await _buildsService.GetAllAsync();
        }
    }
}

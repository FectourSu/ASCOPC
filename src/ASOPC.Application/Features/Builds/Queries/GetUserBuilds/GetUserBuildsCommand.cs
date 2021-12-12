using ASCOPC.Domain.Contracts;
using ASOPC.Application.Features.Builds.Queries.Get;
using ASOPC.Application.Interfaces.Services;
using MediatR;

namespace ASOPC.Application.Features.Builds.Queries.GetUserBuilds
{
    public class GetUserBuildsCommand : IRequest<IResult<IEnumerable<GetBuildResponse>>>
    {
        public string UserId { get; set; }
        public class GetUserBuildsHandler : IRequestHandler<GetUserBuildsCommand, 
            IResult<IEnumerable<GetBuildResponse>>>
        {
            private readonly IBuildsService _buildsService;
            public GetUserBuildsHandler(IBuildsService buildsService)
            {
                _buildsService = buildsService;
            }

            public async Task<IResult<IEnumerable<GetBuildResponse>>> Handle(GetUserBuildsCommand request, 
                CancellationToken cancellationToken) =>
                await _buildsService.GetUserBuildAsync(request.UserId);
        }
    }
}

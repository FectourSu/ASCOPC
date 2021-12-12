using ASCOPC.Domain.Contracts;
using ASOPC.Application.Interfaces.Services;
using MediatR;

namespace ASOPC.Application.Features.Builds.Queries.Get
{
    public class GetBuildCommand : IRequest<IResult<GetBuildResponse>>
    {
        public int Id { get; set; }

        public class GetBuildCommandHandler : IRequestHandler<GetBuildCommand, IResult<GetBuildResponse>>
        {
            private readonly IBuildsService _buildsService;
            public GetBuildCommandHandler(IBuildsService buildsService)
            {
                _buildsService = buildsService; 
            }

            public Task<IResult<GetBuildResponse>> Handle(GetBuildCommand request, 
                CancellationToken cancellationToken) =>
                _buildsService.GetAsync(request.Id);
        }
    }
}

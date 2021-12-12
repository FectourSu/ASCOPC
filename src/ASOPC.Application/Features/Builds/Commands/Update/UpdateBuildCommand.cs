using ASCOPC.Domain.Contracts;
using ASOPC.Application.Interfaces.Services;
using MediatR;

namespace ASOPC.Application.Features.Builds.Commands.Update
{
    public class UpdateBuildCommand : BuildCommand
    {
        public int Id { get; set; }
        public class UpdateBuildHandler : IRequestHandler<UpdateBuildCommand, IResult>
        {
            private readonly IBuildsService _buildsService;

            public UpdateBuildHandler(IBuildsService buildService)
            {
                _buildsService = buildService;
            }
            public async Task<IResult> Handle(UpdateBuildCommand request, CancellationToken cancellationToken) =>
                await _buildsService.UpdateAsync(request);
        }
    }
}

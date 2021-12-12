using ASCOPC.Domain.Contracts;
using ASOPC.Application.Interfaces.Services;
using MediatR;

namespace ASOPC.Application.Features.Builds.Commands.Create
{
    public class DeleteBuildCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public class DeleteBuildHandler : IRequestHandler<DeleteBuildCommand, IResult>
        {
            private readonly IBuildsService _buildsService;

            public DeleteBuildHandler(IBuildsService buildService)
            {
                _buildsService = buildService;
            }
            public async Task<IResult> Handle(DeleteBuildCommand request, CancellationToken cancellationToken) =>
                await _buildsService.DeleteAsync(request.Id);
        }
    }
}

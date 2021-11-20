using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Infrastructure.Data.Enums;
using MediatR;

namespace ASOPC.Application.Features.Builds.Commands.Update
{
    public class UpdateBuildCommand : IRequest<IResult>
    {
        public string Name { get; set; }
        public Category Categories { get; set; }
        public virtual ICollection<Component> Components { get; set; }

        public class UpdateBuildCommandHandler : IRequestHandler<UpdateBuildCommand, IResult>
        {
            public Task<IResult> Handle(UpdateBuildCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

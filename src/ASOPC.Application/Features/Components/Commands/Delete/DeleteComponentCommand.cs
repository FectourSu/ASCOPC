using ASCOPC.Domain.Contracts;
using MediatR;

namespace ASOPC.Application.Features.Components.Commands.Delete
{
    public class DeleteComponentCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteComponentCommandHandler : IRequestHandler<DeleteComponentCommand, IResult>
        {
            public Task<IResult> Handle(DeleteComponentCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

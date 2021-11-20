using ASCOPC.Domain.Contracts;
using MediatR;

namespace ASOPC.Application.Features.Components.Queries.Get
{
    public class GetComponentCommand : IRequest<IResult<GetComponentResponse>>
    {
        public int Id { get; set; }

        public class GetComponentCommandHandler : IRequestHandler<GetComponentCommand, IResult<GetComponentResponse>>
        {
            public Task<IResult<GetComponentResponse>> Handle(GetComponentCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
